using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    public void SpawnBullet(Transform transform)
    {
        var bullet = SpawnObject(transform.position);
    }

    protected override void SubscribeOnEvent(Bullet bullet)
    {
        bullet.TimeOver += ReleaseBullet;
        bullet.HitTraget += ReleaseBullet;
    }

    protected override void UnsubscribeOnEvent(Bullet bullet)
    {
        bullet.TimeOver -= ReleaseBullet;
        bullet.HitTraget -= ReleaseBullet;
    }

    private void ReleaseBullet(Bullet bullet)
    {
        ReleaseObject(bullet);
    }
}
