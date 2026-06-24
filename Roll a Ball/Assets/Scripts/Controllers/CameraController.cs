using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Ссылка на игровой объект игрока.
    public GameObject player;

    // Расстояние между камерой и плеером.
    private Vector3 _offset;

    private void Start()
    {
        // Рассчитайте начальное смещение между положением камеры и положением игрока.
        _offset = transform.position - player.transform.position;
    }

    // LateUpdate вызывается один раз для каждого кадра после завершения всех функций обновления.
    private void LateUpdate()
    {
        // Поддерживайте одинаковое расстояние между камерой и игроком
        transform.position = player.transform.position + _offset;
    }
}
