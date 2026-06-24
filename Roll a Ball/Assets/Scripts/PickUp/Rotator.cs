using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Поверните объект по осям X, Y и Z на заданный угол с учетом частоты кадров.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
