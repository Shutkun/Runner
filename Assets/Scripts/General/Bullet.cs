using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _delayRelease;

    public event Action<Bullet> TimeOver;
    public event Action<Bullet> HitTraget;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(StartTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitTraget?.Invoke(this);
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator StartTimer()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayRelease);

        yield return wait;

        TimeOver?.Invoke(this);
    }
}
