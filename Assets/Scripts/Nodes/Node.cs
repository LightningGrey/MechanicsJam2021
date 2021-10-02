using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private bool _attached;
    public bool IsAttached => _attached;

    private Platform _attachedObject;
    public Platform AttachedObj => _attachedObject;


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
        _attachedObject?.ColourChange();
        _attachedObject = null;
        _attached = false;
        gameObject.transform.DetachChildren();
    }
}
