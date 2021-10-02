using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Vector3 newPos)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        gameObject.transform.position = newPos;

    }
    
}
