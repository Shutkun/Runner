using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageble
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private InputReader _input;
    [SerializeField] private PlayerAttack _attack;

    public event Action GameOver;
    private float _delayGameOver = 2;
    private Coroutine _coroutineGameOver;

    private void OnEnable()
    {
        _health.OnDeath += OnPlayerIsDead;
        _animation.OnShoot += OnPlayerShoot;
        _input.OnJump += _mover.Jump;
        _input.OnAttack += _attack.Attack;
    }

    private void OnDisable()
    {
        _health.OnDeath -= OnPlayerIsDead;
        _animation.OnShoot -= OnPlayerShoot;
        _input.OnJump -= _mover.Jump;
        _input.OnAttack -= _attack.Attack;
        StopCoroutine();
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void Reset()
    {
        StopCoroutine();
        _health.Reset();
        _mover.Reset();
        _animation.Reset();
    }

    private void OnPlayerIsDead()
    {
        _animation.PlayDeadAnimation();
        _mover.DisableAction();
        _coroutineGameOver = StartCoroutine(WaitBeforeGameOver());
    }

    private void StopCoroutine()
    {
        if (_coroutineGameOver != null)
        {
            StopCoroutine(_coroutineGameOver);
        }
    }

    private IEnumerator WaitBeforeGameOver()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayGameOver);
        yield return wait;
        GameOver?.Invoke();
    }

    private void OnPlayerShoot(Transform transform) =>
        _bulletSpawner.SpawnBullet(transform);
}
