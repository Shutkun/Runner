using System.Collections;
using UnityEngine;

public class EnemiesSpawner : Spawner<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private ObjectRemover _remover;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private ScoreCounter _scoreCounter;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Generate());
        _remover.OnScreenOut += ReleaseObject;
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
        _remover.OnScreenOut -= ReleaseObject;
    }

    protected override void SubscribeOnEvent(Enemy enemy)
    {
        enemy.OnShoot += OnEnemyShoot;
        enemy.Release += ReleaseObject;
        enemy.Release += _scoreCounter.Add;
    }

    protected override void UnsubscribeOnEvent(Enemy enemy)
    {
        enemy.OnShoot -= OnEnemyShoot;
        enemy.Release -= ReleaseObject;
        enemy.Release -= _scoreCounter.Add;
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            SpawnObject(GetRandomPosition());
            yield return wait;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float halfWidth = _spawnArea.localScale.x / 2f;
        float halfHeight = _spawnArea.localScale.y / 2f;

        float x = Random.Range(_spawnArea.position.x - halfWidth, _spawnArea.position.x + halfWidth);
        float y = _spawnArea.position.y - halfHeight;
        float z = 0f;

        return new Vector3(x, y, z);
    }

    private void OnEnemyShoot(Transform gunpoint) =>
        _bulletSpawner.SpawnBullet(gunpoint,true);
}
