using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public float minX = -7f;
    public float maxX = 7f;

    public float minY = -4f;
    public float maxY = 4f;

    public float minSpeed = 1f;
    public float maxSpeed = 2.5f;

    public float changeDirectionTime = 3f;

    public float smoothness = 2f;

    private Vector3 targetPosition;
    private Vector3 currentVelocity;

    private float timer;

    private void Start()
    {
        ChooseNewTarget();

        timer = Random.Range(0f, changeDirectionTime);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref currentVelocity,
            smoothness
        );

        if (timer >= changeDirectionTime ||
            Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            ChooseNewTarget();
            timer = 0f;
        }
    }

    private void ChooseNewTarget()
    {
        float newX = Random.Range(minX, maxX);
        float newY = Random.Range(minY, maxY);

        targetPosition = new Vector3(
            newX,
            newY,
            transform.position.z
        );
    }
}