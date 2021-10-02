using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Renderer _renderer;
    private Color _baseColour;

    void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        _baseColour = new Color(91.0f / 255.0f, 1, 0);
    }

    void MovePlatform()
    {
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {

        yield return new WaitForSeconds(.1f);
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
