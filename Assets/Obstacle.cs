using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed;

    public void SetTarget(Vector3 target, float moveSpeed)
    {
        targetPosition = target;
        speed = moveSpeed;
    }

    void Update()
    {
        // Move the obstacle toward the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Destroy the obstacle if it reaches the center (or past the orbit)
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
