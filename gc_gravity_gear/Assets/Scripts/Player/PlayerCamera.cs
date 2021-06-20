using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform parent;

    public float mouseSens;
    public float xRotation;

    // preferably maxClamp a positive number, minClamp negative, like 80 & -80)
    public float maxClamp;
    public float minClamp;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minClamp, maxClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        parent.Rotate(Vector3.up * mouseX);
    }
}
