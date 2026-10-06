using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetBulletDirection();
    }

    private void SetBulletDirection()
    {
        _rigidbody2D.linearVelocity = new Vector2(_speed, _rigidbody2D.linearVelocity.y);
    }
}
