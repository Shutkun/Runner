using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    private int _layerPlayerBullet = 8;
    private int _layerEnemyBullet = 9;

    public void SpawnBullet(Transform transform, bool isEnemyBullet)
    {
        var bullet = SpawnObject(transform.position);

        if (bullet.TryGetComponent<BulletMover>(out BulletMover mover))
        {
            mover.SetCall(isEnemyBullet);
        }

        if (isEnemyBullet)
        {
            bullet.gameObject.layer = _layerEnemyBullet;
        }
        else
        {
            bullet.gameObject.layer = _layerPlayerBullet;
        }
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
