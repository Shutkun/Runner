using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private InputReader _input;

    public bool IsCanAction => _isCanAction;
    private Vector3 _startPosition;
    private bool _isOnAGround;
    private bool _isCanAction = true;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _input.OnJump += Jump;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        Reset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            _isOnAGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            _isOnAGround = false;
        }
    }

    private void OnDisable()
    {
        _input.OnJump -= Jump;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody2D.linearVelocity = Vector2.zero;
        _isCanAction = true;
    }

    public void DisableAction()
    {
        _isCanAction = false;
    }

    private void Jump()
    {
        if (_isOnAGround == true && _isCanAction == true)
        {
            _animation.PlayJumpAnimation();
            _rigidbody2D.linearVelocity = new Vector2(_speed, _tapForce);
        }
    }
}
