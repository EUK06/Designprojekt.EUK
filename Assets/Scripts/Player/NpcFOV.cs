using UnityEngine;

public class NpcFOV : MonoBehaviour
{
    public Transform npcToLookAt; // NPC to look at
    public float loweredFOV = 30f; // FOV value when looking at the NPC
    public float originalFOV = 60f; // Original FOV value
    public float easeInSpeed = 5f; // Speed of easing in the FOV change
    public float easeOutSpeed = 2f; // Speed of easing out the FOV change
    public float shakeIntensity = 0.1f; // Intensity of the camera shake

    private Camera mainCamera;
    private bool isLookingAtNPC = false;
    private float originalFieldOfView;
    private Vector3 originalCameraPosition;

    private void Start()
    {
        mainCamera = Camera.main;
        originalFieldOfView = mainCamera.fieldOfView;
        originalCameraPosition = mainCamera.transform.localPosition;
    }

    private void Update()
    {
        // Check if the player is looking at the NPC
        Vector3 direction = npcToLookAt.position - transform.position;
        float angle = Vector3.Angle(transform.forward, direction);
        if (angle <= 30f) // Adjust the angle threshold as needed
        {
            if (!isLookingAtNPC)
            {
                isLookingAtNPC = true;
            }
        }
        else
        {
            if (isLookingAtNPC)
            {
                isLookingAtNPC = false;
            }
        }

        // Adjust the FOV based on whether looking at the NPC
        if (isLookingAtNPC)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, loweredFOV, Time.deltaTime * easeInSpeed);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, originalFieldOfView, Time.deltaTime * easeOutSpeed);
        }

        // Shake the camera while looking at the NPC
        if (isLookingAtNPC)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;
            mainCamera.transform.localPosition = originalCameraPosition + shakeOffset;
        }
        else
        {
            mainCamera.transform.localPosition = originalCameraPosition;
        }
    }
}
