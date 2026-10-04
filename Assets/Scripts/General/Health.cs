using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action OnDeath;
    private int _currentHealth;
    private bool _isDead;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead)
        {
            return;
        }

        ChangeValue(-damage);
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
    }

    private void ChangeValue(int value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0)
        {
            _isDead = true;
            OnDeath?.Invoke();
        }

    }
}
