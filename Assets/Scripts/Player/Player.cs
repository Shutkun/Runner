using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageble
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private PlayerMover _mover;

    public event Action GameOver;
    private float _delayGameOver = 2;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.OnDeath += onPlayerIsDead;
        _animation.OnShoot += onPlayerShoot;
    }

    private void OnDisable()
    {
        _health.OnDeath -= onPlayerIsDead;
        _animation.OnShoot -= onPlayerShoot;
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

    private void onPlayerIsDead()
    {
        _animation.PlayDeadAnimation();
        _mover.DisableAction();
        _coroutine = StartCoroutine(WaitBeforeGameOver());
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator WaitBeforeGameOver()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayGameOver);
        yield return wait;
        GameOver?.Invoke();
    }

    private void onPlayerShoot(Transform transform) =>
        _bulletSpawner.SpawnBullet(transform, false);
}
