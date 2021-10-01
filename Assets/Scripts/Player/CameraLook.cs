using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//thank you Brackeys
//https://www.youtube.com/watch?v=_QajrabyTJc
public class CameraLook : MonoBehaviour
{

    [SerializeField] private float _mouseSensitivity = 100.0f;
    [SerializeField] private Transform _player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _player.Rotate(Vector3.up * mouseX);
    }
}
