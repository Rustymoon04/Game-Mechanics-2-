using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbitController : MonoBehaviour
{
    public Transform centerPoint;
    public float orbitSpeed = 100f;
    private bool isReversed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isReversed = !isReversed;
        }

        float direction = isReversed ? -1f : 1f;
        transform.RotateAround(centerPoint.position, Vector3.forward, direction * orbitSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
