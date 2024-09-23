using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedTurn;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clipMove;

    private Rigidbody _rigidbody;
    private bool _isBeyondBordersRight = false;
    private bool _isBeyondBordersLeft = false;
    private float _currentTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float axis = Input.GetAxis("Horizontal");
        Vector3 forwardMovement = transform.forward * _speed * Time.deltaTime;
        Vector3 lateralMovement = Vector3.zero;

        if (axis != 0)
        {
            if (!_isBeyondBordersRight && axis > 0)
                lateralMovement = transform.right * _speed * Time.deltaTime;

            if (!_isBeyondBordersLeft && axis < 0)
                lateralMovement = -transform.right * _speed * Time.deltaTime;

            Rotate((transform.right * axis) + transform.forward);
        }
        else
        {
            Rotate(transform.forward);
        }

        // Сложить перемещения
        Vector3 movement = forwardMovement + lateralMovement;

        // Применить перемещение
        _rigidbody.MovePosition(_rigidbody.position + movement);

        if (_currentTime > 0.8f)
        {
            _currentTime = 0;
            _audioSource.PlayOneShot(_clipMove);
        }

        _currentTime += Time.deltaTime;
    }

    private void Rotate(Vector3 dir)
    {
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(_playerModel.rotation, lookRotation, _speedTurn * Time.deltaTime).eulerAngles;
        _playerModel.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground")
            return;

        if (Input.GetAxis("Horizontal") > 0)
            _isBeyondBordersRight = true;
        else
            _isBeyondBordersLeft = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Ground")
            return;

        if (_isBeyondBordersRight)
            _isBeyondBordersRight = false;

        if (_isBeyondBordersLeft)
            _isBeyondBordersLeft = false;
    }
}
