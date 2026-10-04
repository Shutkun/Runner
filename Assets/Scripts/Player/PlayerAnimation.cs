using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly int _onAttack = Animator.StringToHash(nameof(_onAttack));
    private readonly int _onJump = Animator.StringToHash(nameof(_onJump));
    private readonly int _onDead = Animator.StringToHash(nameof(_onDead));
    private readonly int _onReset = Animator.StringToHash(nameof(_onReset));

    [SerializeField] private float _cooldown;
    [Space]
    [SerializeField] private Transform _gunPoint;

    public event Action<Transform> OnShoot;
    private bool _canAttack = true;
    private Animator _animator;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        StopCoroutine();
    }

    public void Attack()
    {
        if( _canAttack == false)
        {
            return;
        }

        _canAttack = false;
        PlayAttackAnimation();
        _coroutine = StartCoroutine(CoolDown());
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(_onJump);
    }

    public void PlayDeadAnimation()
    {
        _animator.SetTrigger(_onDead);
    }

    public void Reset()
    {
        _animator.SetTrigger(_onReset);
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_cooldown);
        _canAttack = true;
    }

    private void PlayAttackAnimation()
    {
        _animator.SetTrigger(_onAttack);
        OnShoot?.Invoke(_gunPoint);
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
