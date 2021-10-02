using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnector : MonoBehaviour
{
    private GameObject _connector = null;

    public void Connect(Vector3 leftPos, Vector3 rightPos)
    {
        //Debug.Log(rightPos - leftPos);

        //create
        if (_connector == null)
        {
            _connector = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _connector.GetComponent<Renderer>().material.color = 
                new Color(49.0f/255.0f, 219.0f / 255.0f, 146.0f / 255.0f);
            _connector.tag = "Node";
            _connector.layer = 6;
        }

        if (!_connector.activeSelf)
        {
            _connector.SetActive(true);
        }

        //connector adjustment
        Vector3 vecDist = rightPos - leftPos;
        float dist = vecDist.magnitude;

        _connector.transform.localScale = new Vector3(dist, _connector.transform.localScale.y, _connector.transform.localScale.z);
        _connector.transform.position = leftPos + (vecDist / 2.0f);
        _connector.transform.LookAt(rightPos);
        _connector.transform.Rotate(0, 90, 0, Space.Self);
    }

    public void Reset()
    {
        if (_connector != null)
        {
            _connector.SetActive(false);
        }
    }

}
