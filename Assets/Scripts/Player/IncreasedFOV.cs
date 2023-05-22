using UnityEngine;

public class IncreasedFOV : MonoBehaviour
{
    public float increaseAmount = 10f; // Amount by which to increase the FOV

    private Camera mainCamera;
    private float originalFOV;

    private void Start()
    {
        mainCamera = Camera.main;
        originalFOV = mainCamera.fieldOfView;
    }

    private void Update()
    {
        // Check for input to increase the FOV
        if (Input.GetKeyDown(KeyCode.I))
        {
            IncreaseFOV();
        }

        // Check for input to reset the FOV to its original value
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetFOV();
        }
    }

    private void IncreaseFOV()
    {
        mainCamera.fieldOfView += increaseAmount;
    }

    private void ResetFOV()
    {
        mainCamera.fieldOfView = originalFOV;
    }
}
