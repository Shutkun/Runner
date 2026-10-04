using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action OnDeath;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)=>
        ChangeValue(-damage);

    public void Reset() =>
        _currentHealth = _maxHealth;

    private void ChangeValue(int value)
    {
        if(_currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }

        _currentHealth += value;
    }
}
