using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f;   // Distance of each move; should match your grid cell size
    public float moveSpeed = 5f;      // Speed of the movement animation
    private bool isMoving = false;    // Tracks if player is currently moving

    private void Update()
    {
        if (!isMoving)  // Only process input if player is not moving
        {
            Vector3 targetPosition = transform.position;

            // Get input and calculate the new target position
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                targetPosition += Vector3.forward * moveDistance;       // Move up
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                targetPosition += Vector3.back * moveDistance;     // Move down
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                targetPosition += Vector3.left * moveDistance;     // Move left
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                targetPosition += Vector3.right * moveDistance;    // Move right

            // If target position has changed, start moving
            if (targetPosition != transform.position)
                StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;

        // Smoothly move the player to the target position
        while ((targetPosition - transform.position).sqrMagnitude > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap to target position (to avoid floating-point inaccuracies)
        transform.position = targetPosition;
        isMoving = false;
    }
}
