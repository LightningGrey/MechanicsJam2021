using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private bool _attached;
    public bool IsAttached => _attached;

    private Platform _attachedObject;
    public Platform AttachedObj => _attachedObject;


    private Vector3 _vecDist;
    private Vector3 _midDist;

    public void Spawn(RaycastHit hit)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        //detach if clicking elsewhere
        ChildReset();
        gameObject.transform.position = hit.point;

        //keep attached if true
        if (hit.collider.gameObject.tag == "Platform")
        {
            hit.collider.gameObject.transform.parent = gameObject.transform;

            _attachedObject = hit.collider.gameObject.GetComponent<Platform>();
            _attachedObject.ColourChange(gameObject.GetComponent<Renderer>().material.color);
            _attached = true;
        }

    }

    public void Reset()
    {
        ChildReset();
        gameObject.SetActive(false);
    }

    public void ChildReset()
    {
        StopCoroutine("Move");


        _attachedObject?.ColourChange();
        _attachedObject?.MovePlatform();

        _attachedObject = null;
        _attached = false;
        if (gameObject.transform.childCount >= 2)
        {
            gameObject.transform.GetChild(1);
        }
    }

    public void PreMove(Node otherNode)
    {
        //calculate midpoint
        _midDist = (transform.position + otherNode.transform.position)/2.0f;
     
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        while (!transform.position.Equals(_midDist))
        {
            //Debug.Log(Vector3.Distance(transform.position, _midDist));

            transform.position = Vector3.MoveTowards(transform.position,
                _midDist, 0.3f);
            yield return new WaitForSeconds(.04f);

            if (transform.position.Equals(_midDist))
            {
                //Debug.Log("pain");
                StopCoroutine("Move");
            }
        }
    }

}
