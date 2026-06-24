using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Жесткое тело игрока.
    private Rigidbody _rb;

    // Перемещение по осям X и Y.
    private float _movementX;
    private float _movementY;

    // Скорость, с которой движется игрок.
    public float speed = 0.0f;

    private void Start()
    {
        // Достаньте и сохраните компонент Rigidbody, прикрепленный к проигрывателю.
        _rb = GetComponent<Rigidbody>();
    }


    // Эта функция вызывается при обнаружении входного сигнала перемещения.
    void OnMove(InputValue movememtValue)
    {
        // Преобразуйте входное значение в вектор2 для перемещения.
        Vector2 movementVector = movememtValue.Get<Vector2>();

        // Сохраните X и Y компоненты движения.
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }


    // FixedUpdate вызывается один раз для каждого кадра с фиксированной частотой кадров.
    private void FixedUpdate()
    {
        // Создайте трехмерный вектор движения, используя входные данные X и Y.
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);

        // Приложите усилие к жесткому телу, чтобы переместить игрока.
        _rb.AddForce(movement * speed);
    }
}
