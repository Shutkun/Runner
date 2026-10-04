using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private T _prefab;
    private Stack<T> _objects = new();

    public Pool(T prefab)
    {
        _prefab = prefab;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Push(obj);
    }

    public T GetObject()
    {
        if (_objects.Count == 0)
        {
            Create();
        }

        return _objects.Pop();
    }

    private void Create()
    {
        var obj = Object.Instantiate(_prefab);
        obj.gameObject.SetActive(false);
        _objects.Push(obj);
    }
}
