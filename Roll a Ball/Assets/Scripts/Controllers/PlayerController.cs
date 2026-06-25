using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Жесткое тело игрока.
    private Rigidbody _rb;

    // Перемещение по осям X и Y.
    private float _movementX;
    private float _movementY;

    // Переменная для отслеживания собранных объектов PickUp.
    private int count;

    // Скорость, с которой движется игрок.
    public float speed = 0.0f;

    // Текстовый компонент пользовательского интерфейса для отображения количества
    // собранных объектов PickUp.
    public TextMeshProUGUI countText;

    // Объект пользовательского интерфейса для отображения текста с выигрышной комбинацией.
    public GameObject winTextObject;

    private void Start()
    {
        // Достаньте и сохраните компонент Rigidbody, прикрепленный к проигрывателю.
        _rb = GetComponent<Rigidbody>();

        // Инициализируйте счетчик равным нулю.
        count = 0;

        // Обновите отображение количества.
        SetCountText();

        // Изначально текст с выигрышной комбинацией был неактивным.
        winTextObject.SetActive(false);
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


    private void OnTriggerEnter(Collider other)
    {
        // Проверьте, есть ли у объекта, с которым столкнулся игрок, тег PickUp.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Деактивируйте столкнувшийся объект (чтобы он исчез).(удаление)
            Destroy(other.gameObject);

            // Увеличьте количество собранных объектов PickUp.
            count++;

            // Обновите отображение количества.
            SetCountText();
        }
    }


    // Функция для обновления отображаемого количества собранных объектов PickUp.
    private void SetCountText()
    {
        // Обновите текст с указанием текущего количества.
        countText.text = $"Count: {count}";

        // Проверьте, достигло ли количество очков условия выигрыша или превысило его.
        if (count >= 13)
        {
            // Отобразите текст выигрыша.
            winTextObject.SetActive(true);
        }
    }
}
