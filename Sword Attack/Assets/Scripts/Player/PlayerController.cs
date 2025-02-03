using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 100f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;

    private void Start()
    {
        CheckRequirements();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void CheckRequirements()
    {
        if (_rigidbody2D == null)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        _velocity = new Vector2(horizontalInput, verticalInput);
        _rigidbody2D.MovePosition(_rigidbody2D.position + _velocity * Time.fixedDeltaTime * _playerSpeed);
    }
}