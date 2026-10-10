using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private Vector2 touchStart;
    private bool isDragging;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement = Vector2.zero;

        // Touch على الموبايل
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved ||
                     touch.phase == TouchPhase.Stationary)
            {
                if (isDragging)
                {
                    Vector2 dragDirection = touch.position - touchStart;

                    if (dragDirection.magnitude > 20f)
                    {
                        movement = dragDirection.normalized;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended ||
                     touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
                movement = Vector2.zero;
            }
        }

        // Mouse للاختبار داخل Simulator
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 dragDirection =
                (Vector2)Input.mousePosition - touchStart;

            if (dragDirection.magnitude > 20f)
            {
                movement = dragDirection.normalized;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            movement = Vector2.zero;
        }

        // Flip حسب اتجاه الحركة
        if (movement.x > 0.05f)
        {
            // يتحرك لليمين
            spriteRenderer.flipX = false;
        }
        else if (movement.x < -0.05f)
        {
            // يتحرك لليسار
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }
}