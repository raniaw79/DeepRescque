using UnityEngine;

public class TrashCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TrashCounter.Instance.AddTrash();

            Vector3 newPosition = transform.position;
            newPosition.y = 6f;
            transform.position = newPosition;
        }
    }
}