using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject boosterFlame;

    [SerializeField] private float thrustForce = 1.0f;
    [SerializeField] private float maxSpeed = 5f;
   

    private Rigidbody2D rigidbody2D;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                boosterFlame.SetActive(true);
            }

            // Calculate mouse direction.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePosition - transform.position).normalized;

            // Move player in direction of mouse.
            transform.up = direction;
            rigidbody2D.AddForce(direction * thrustForce);

            if(rigidbody2D.linearVelocity.magnitude > maxSpeed)
            {
                rigidbody2D.linearVelocity = rigidbody2D.linearVelocity.normalized * maxSpeed;
            }
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
