using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly int _onAttack = Animator.StringToHash(nameof(_onAttack));
    private readonly int _onJump = Animator.StringToHash(nameof(_onJump));
    private readonly int _isDead = Animator.StringToHash(nameof(_isDead));
    private readonly int _onReset = Animator.StringToHash(nameof(_onReset));

    [SerializeField] private Transform _gunPoint;

    public event Action<Transform> OnShoot;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(_onJump);
    }

    public void PlayDeadAnimation()
    {
        _animator.SetBool(_isDead, true);
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger(_onAttack);
        OnShoot?.Invoke(_gunPoint);
    }

    public void Reset()
    {
        _animator.SetBool(_isDead, false);
    }
}
