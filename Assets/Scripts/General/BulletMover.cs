using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rb;
    private bool _isEnemyCall = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        SetBulletDirection();
    }

    public void SetCall(bool isEnemy) =>
        _isEnemyCall = isEnemy;

    private void SetBulletDirection()
    {
        if (_isEnemyCall)
        {
            _rb.linearVelocity = new Vector2(-_speed, _rb.linearVelocity.y);
        }
        else
        {
            _rb.linearVelocity = new Vector2(_speed, _rb.linearVelocity.y);
        }
    }
}
