using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _jump = KeyCode.Space;
    private KeyCode _attack = KeyCode.E;

    public event Action OnJump;
    public event Action OnAttack;

    private void Update()
    {
        Jump();
        Attack();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_jump))
        {
            OnJump?.Invoke();
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(_attack))
        {
            OnAttack?.Invoke();
        }
    }
}
