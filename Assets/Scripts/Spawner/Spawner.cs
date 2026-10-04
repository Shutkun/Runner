using UnityEngine;

public abstract class Spawner <T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected Transform Container;

    private Pool<T> _pool;

    private void Awake()
    {
        _pool = new Pool<T>(Prefab);
    }

    protected T SpawnObject(Vector3 position)
    {
        T obj = _pool.GetObject();
        obj.transform.SetParent(Container);
        obj.gameObject.transform.position = position;
        obj.gameObject.SetActive(true);
        SubscribeOnEvent(obj);

        return obj;
    }

    protected void ReleaseObject(T obj)
    {
        UnsubscribeOnEvent(obj);
        _pool.Release(obj);
    }

    protected virtual void SubscribeOnEvent(T obj) { }
    protected virtual void UnsubscribeOnEvent(T obj) { }
}
