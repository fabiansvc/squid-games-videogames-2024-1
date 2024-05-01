using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Public_Variables
    public float mouseSensitivity;
    public float bottomAngle;
    public float topAngle;
    public float yRotationSpeed;
    public float xCameraSpeed;
    #endregion

    #region Private_Variables
    private float desiredYRotation;
    private float desiredCameraXRotation;
    private float currentYRotation;
    private float currentCameraXRotation;
    private float rotationYVelocity;
    private float cameraXVelocity;
    private Transform myCamera;
    #endregion

    void Awake()
    {
        myCamera = Camera.main.transform;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseInputMovement();
    }

    void FixedUpdate()
    {
        ApplyRotation();
    }

    void MouseInputMovement()
    {
        // Roation of the capsule in the Y axis
        desiredYRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        // Rotation of the camera in the X axis
        desiredCameraXRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        // Limit the camera rotation
        desiredCameraXRotation = Mathf.Clamp(desiredCameraXRotation, bottomAngle, topAngle); 
    }

    void ApplyRotation()
    {
        // Smooth the rotation
        currentYRotation = Mathf.SmoothDamp(currentYRotation, desiredYRotation, ref rotationYVelocity, yRotationSpeed);
        currentCameraXRotation = Mathf.SmoothDamp(currentCameraXRotation, desiredCameraXRotation, ref cameraXVelocity, xCameraSpeed);

        // Apply the rotation to the capsule
        transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
        // Apply the rotation to the camera
        myCamera.localRotation = Quaternion.Euler(currentCameraXRotation, 0, 0);
    }
}
