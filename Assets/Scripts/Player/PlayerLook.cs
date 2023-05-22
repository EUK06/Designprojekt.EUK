using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private InputManager inputManager; // declare a reference to the InputManager

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>(); // find the InputManager instance in the scene
    }

    private void LateUpdate()
    {
        // get the look input from the InputManager
        Vector2 lookInput = inputManager.onFoot.Look.ReadValue<Vector2>();
        ProcessLook(lookInput);
    }

    public void ProcessLook(Vector2 Input)
    {
        float mouseX = Input.x;
        float mouseY = Input.y;
        //calculate camera rotation for looking upp and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotate player to look left and right.
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);

    }
}
