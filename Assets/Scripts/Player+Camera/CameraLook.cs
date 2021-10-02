using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//thank you Brackeys
//https://www.youtube.com/watch?v=_QajrabyTJc
public class CameraLook : MonoBehaviour
{

    [SerializeField] private float _mouseSensitivity = 100.0f;
    [SerializeField] private Transform _player;

    private float xRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        _player.Rotate(Vector3.up * mouseX);
    }
}
