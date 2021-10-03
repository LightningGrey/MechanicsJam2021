using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnector : MonoBehaviour
{
    public void Connect(Vector3 leftPos, Vector3 rightPos)
    {

        gameObject.SetActive(true);

        //connector adjustment
        Vector3 vecDist = rightPos - leftPos;
        float dist = vecDist.magnitude;

        transform.localScale = new Vector3(dist, transform.localScale.y, transform.localScale.z);
        transform.position = leftPos + (vecDist / 2.0f);
        transform.LookAt(rightPos);
        transform.Rotate(0, 90, 0, Space.Self);
    }

    IEnumerator Move()
    {

        yield return new WaitForSeconds(.1f);
    }

}
