using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _swordSprite;
    [SerializeField] private Rigidbody2D _swordRigibody2D;

    private float _flightTime;
    private float _currentSpeed;
    
    private Vector2 _startPosition;
    private Vector2 _initialDirection;
    
    private bool _isThrowed;
    private bool _isReturning;
    
    private Transform _owner;
    private SwordScriptableObject _swordPattern;

    private const float _speedProgressMultiplier = 0.2f;

    public void Throw(Transform owner, Vector3 direction, SwordScriptableObject swordPattern)
    {
        if (_isReturning || _isThrowed) return;

        _owner = owner;
        _swordPattern = swordPattern;
        _initialDirection = direction.normalized;

        _isThrowed = true;
        _swordSprite.enabled = true;
        _startPosition = _owner.position;
        transform.position = _startPosition;

        _flightTime = 0f;
        _currentSpeed = 0f;
    }

    private void FixedUpdate()
    {
        if (_swordPattern)
        {
            transform.Rotate(Vector3.forward, _swordPattern.RotationSpeed * Time.fixedDeltaTime);

            if (_isThrowed && !_isReturning)
            {
                _flightTime += Time.fixedDeltaTime;

                float speedProgress = Mathf.SmoothStep(0f, 1f, _flightTime / (_swordPattern.ReturnDelay * _speedProgressMultiplier));
                _currentSpeed = Mathf.Lerp(0f, _swordPattern.ThrowForce, speedProgress);

                float angle = Mathf.Lerp(0, Mathf.PI, _flightTime / _swordPattern.ReturnDelay);

                float x = Mathf.Cos(angle) * _swordPattern.TrajectoryAngle;
                float y = Mathf.Sin(angle) * _swordPattern.TrajectoryAngle;

                if (_swordPattern.TrajectoryAngle < 0)
                {
                    y = -y;
                }

                Vector2 arcOffset = new Vector2(x, y);
                Vector2 arcPosition = _startPosition + (_initialDirection * x) + (Vector2.Perpendicular(_initialDirection) * y);

                _swordRigibody2D.MovePosition(Vector2.Lerp(transform.position, arcPosition, _currentSpeed * Time.fixedDeltaTime));

                if (_flightTime >= _swordPattern.ReturnDelay)
                {
                    _isThrowed = false;
                    _isReturning = true;
                }
            }

            if (_isReturning)
            {
                transform.position = Vector2.MoveTowards(transform.position, _owner.position, _swordPattern.ReturnSpeed * Time.fixedDeltaTime);

                if (Vector2.Distance(transform.position, _owner.position) < _swordPattern.CatchOffset)
                {
                    ResetSword();
                }
            }
        }
    }

    private void ResetSword()
    {
        _isThrowed = false;
        _isReturning = false;
        _swordSprite.enabled = false;
        _swordRigibody2D.velocity = Vector2.zero;
    }

    private void OnCollisionEnteê2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Enemy"))
        {

        }
    }
}