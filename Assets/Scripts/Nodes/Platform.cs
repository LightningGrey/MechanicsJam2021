using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    void MovePlatform()
    {
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {

        yield return new WaitForSeconds(.1f);
    }



}
