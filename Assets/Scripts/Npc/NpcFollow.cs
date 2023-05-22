using UnityEngine;

public class NpcFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    private void Update()
    {
        // Calculate the direction from NPC to the player (ignore Y-axis)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // Set the Y-component to 0 to ignore changes in Y position
        direction.Normalize();

        // Move towards the player
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
