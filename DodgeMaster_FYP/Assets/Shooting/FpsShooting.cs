using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FpsShooting : MonoBehaviour
{
    //mouseSenstivity controls how fast mouse changes its position
    public float mouseSenstivity=1.5f;
    //playerBody get Player
    public Transform playerBody;
    //xRotation for rotate camera around x-axis
    float xRotation = 0f;

    private void Start()
    {
        //Hide Cursor
       // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Un Hide Cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //get mouse x & y axis values
        //For Rotate With Mouse
        //float mouseX = Input.GetAxis("Mouse X") * mouseSenstivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSenstivity * Time.deltaTime;


        //For Rotate with touchpad
        float mouseX = CrossPlatformInputManager.GetAxis("Mouse X") * mouseSenstivity;
        float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y") * mouseSenstivity;

        //take mouse y-axis values for camera rotation around x-axis
        //subtract for not flip
        xRotation -= mouseY;

        //Clamp for avoid go behind player
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        //Rotate camera around its x-axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Rotate player around its y-axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
