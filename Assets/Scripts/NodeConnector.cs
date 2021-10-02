using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnector : MonoBehaviour
{
    private GameObject cube = null;

    public void Connect(Vector3 leftPos, Vector3 rightPos)
    {
        //Debug.Log(rightPos - leftPos);

        if (cube == null)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.GetComponent<Renderer>().material.color = 
                new Color(49.0f/255.0f, 219.0f / 255.0f, 146.0f / 255.0f);
            cube.tag = "Node";
            cube.layer = 6;
        }

        //connector adjustment
        Vector3 vecDist = rightPos - leftPos;
        float dist = vecDist.magnitude;

        cube.transform.localScale = new Vector3(dist, cube.transform.localScale.y, cube.transform.localScale.z);
        cube.transform.position = leftPos + (vecDist / 2.0f);
        cube.transform.LookAt(rightPos);
        cube.transform.Rotate(0, 90, 0, Space.Self);
    }

}
