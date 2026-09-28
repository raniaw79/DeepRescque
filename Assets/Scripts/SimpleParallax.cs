using UnityEngine;

public class SimpleParallax : MonoBehaviour
{
    public Transform player;
    public float parallaxAmount = 0.05f;

    private Vector3 startPosition;
    private Vector3 playerStartPosition;

    private void Start()
    {
        startPosition = transform.position;
        playerStartPosition = player.position;
    }

    private void Update()
    {
        Vector3 playerMovement = player.position - playerStartPosition;

        transform.position = new Vector3(
            startPosition.x + playerMovement.x * parallaxAmount,
            startPosition.y + playerMovement.y * parallaxAmount,
            startPosition.z
        );
    }
}