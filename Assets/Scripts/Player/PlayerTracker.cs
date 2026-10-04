using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _palyer;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _palyer.transform.position.x + _xOffset;
        transform.position = position;
    }
}
