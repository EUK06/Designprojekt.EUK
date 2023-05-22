using UnityEngine;

public class ArmatureRotate : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f;

    private void Update()
    {
        if (player != null)
        {
            // Get the direction from the armature to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Ignore the vertical component to keep the armature facing horizontally
            directionToPlayer.y = 0f;

            // Rotate the armature to face the player
            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
