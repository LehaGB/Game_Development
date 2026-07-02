using UnityEngine;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private float minSize = 0.5f;
    [SerializeField] private float maxSize = 1.8f;

    [SerializeField] private float minSpeed = 50f;
    [SerializeField] private float maxSpeed = 150f;

    [SerializeField] private float maxSpinSped = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1f);

        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;

        rb = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);

        float randomTorque = Random.Range(-maxSpinSped, maxSpinSped) / randomSize;
        rb.AddTorque(randomTorque);
    }
}
