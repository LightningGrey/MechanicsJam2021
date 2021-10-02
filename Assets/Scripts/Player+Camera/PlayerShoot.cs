using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _leftNode;
    private GameObject _activeLeft = null;

    [SerializeField] private GameObject _rightNode;
    private GameObject _activeRight = null;

    [SerializeField] private Camera _cam;

    [SerializeField] private NodeConnector _connector;

    [Header("Values")]
    [SerializeField] private float _range = 50.0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(true);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot(false);
        }


    }

    void Shoot(bool left)
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _range) 
            && hit.transform.tag != "Node")
        {
            //man this looks gross lol
            if (left)
            {
                if (_activeLeft != null)
                {
                    _activeLeft.transform.position = hit.point;
                }
                else
                {
                    _activeLeft = Instantiate(_leftNode, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
            else
            {
                if (_activeRight != null)
                {
                    _activeRight.transform.position = hit.point;
                }
                else
                {
                    _activeRight = Instantiate(_rightNode, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }

            //if both nodes are active, call connector
            if (_activeLeft && _activeRight)
            {
                //Debug.Log("both active");
                _connector.Connect(_activeLeft.transform.position, _activeRight.transform.position);
            }
        }
    }

}
