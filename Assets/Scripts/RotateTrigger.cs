using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    [SerializeField] private bool _isRightRotate;
    private float _speedTurn = 4f;
    private Quaternion _lookRotation;

    private void OnTriggerEnter(Collider other)
    {
        // Определяем направление поворота в зависимости от флага
        Vector3 direction = _isRightRotate ? other.transform.right : -other.transform.right;
        _lookRotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerStay(Collider other)
    {
        // Плавно поворачиваем объект в сторону заданного направления
        Quaternion currentRotation = other.transform.rotation;
        other.transform.rotation = Quaternion.Lerp(currentRotation, _lookRotation, _speedTurn * Time.deltaTime);
    }
}
