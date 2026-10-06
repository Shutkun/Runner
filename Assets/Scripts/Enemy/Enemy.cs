using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private float _delayShooting;
    [Space]
    [SerializeField] private Transform _gunpoint;
    [SerializeField] private Health _health;

    public event Action<Transform> OnShoot;
    public event Action<Enemy> Release;

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnEnable()
    {
        _health.OnDeath += EnemyIsDown;
    }

    private void OnDisable()
    {
        _health.OnDeath -= EnemyIsDown;
    }

    public void StartShoot()
    {
        OnShoot?.Invoke(this._gunpoint);
    }

    private void EnemyIsDown()
    {
        Release?.Invoke(this);
    }
}