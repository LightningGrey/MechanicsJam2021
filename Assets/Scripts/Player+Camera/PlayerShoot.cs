using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera _cam;

    [SerializeField] private NodeManager _manager;

    [SerializeField] private AudioSource _audio;

    [Header("Values")]
    [SerializeField] private float _range = 50.0f;


    // Update is called once per frame
    void Update()
    {
        //shoot spheres
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(true);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot(false);
        }
        if (Input.GetButtonDown("Fire3"))
        {
            _manager.Reset();
        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    void Shoot(bool left)
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _range) 
            && hit.transform.tag != "Node")
        {
            _manager.UpdateNode(left, hit);

        }

        _audio.Play();
    }

}
