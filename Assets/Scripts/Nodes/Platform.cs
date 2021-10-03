using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Renderer _renderer;
    
    //[SerializeField] 
    private Color _baseColour = new Color(0, 1, 0);
    private Vector3 _basePosition;

    void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        _basePosition = transform.position;
    }

    public void MovePlatform()
    {
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        while (!transform.position.Equals(_basePosition))
        {

            transform.position = Vector3.MoveTowards(transform.position,
                _basePosition, 0.3f);
            yield return new WaitForSeconds(.04f);

            if (transform.position.Equals(_basePosition))
            {
                //Debug.Log("pain");
                StopCoroutine("Move");
            }
        }
    }


    //overload function cause lazy
    public void ColourChange()
    {
        _renderer.material.color = _baseColour;
    }
    public void ColourChange(Color colour)
    {
        _renderer.material.color = colour;
    }

    public void Reset()
    {
       ColourChange();
    }


}
