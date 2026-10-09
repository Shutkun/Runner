using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _cooldownAttack;
    [Space]
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private PlayerMover _mover;

    private Coroutine _coroutine;
    private bool _canAttack = true;

    private void OnDisable()
    {
        StopCoroutine();
    }

    public void Attack()
    {
        if (_canAttack == false || _mover.IsCanAction == false)
        {
            return;
        }

        _canAttack = false;
        _animation.PlayAttackAnimation();
        _coroutine = StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_cooldownAttack);
        _canAttack = true;
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
