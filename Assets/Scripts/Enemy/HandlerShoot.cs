using UnityEngine;

public class HandlerShoot : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void Shoot()
    {
        _enemy.StartShoot();
    }
}
