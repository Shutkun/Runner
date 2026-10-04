using System;
using UnityEngine;

public class ObjectRemover:  MonoBehaviour
{
    public event Action<Enemy> OnScreenOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy poolObject))
        {
            OnScreenOut?.Invoke(poolObject);
        }
    }
}