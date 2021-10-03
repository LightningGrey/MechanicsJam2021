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
        while (transform.localScale.x > 1.0f)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.6f, transform.localScale.y,
                transform.localScale.z);
            yield return new WaitForSeconds(.04f);
            if (transform.localScale.x <= 1.0f)
            {
                StopCoroutine("Move");
            }
        }
    }

}
