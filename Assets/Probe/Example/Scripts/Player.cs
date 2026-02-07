using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 _moveInput;
    void Update()
    {
        _moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) _moveInput.x -= 1f;
            if (Keyboard.current.dKey.isPressed) _moveInput.x += 1f;
            if (Keyboard.current.sKey.isPressed) _moveInput.y -= 1f;
            if (Keyboard.current.wKey.isPressed) _moveInput.y += 1f;
        }

        _moveInput = _moveInput.normalized;
        Vector3 dir = new Vector3(_moveInput.x, _moveInput.y, 0f).normalized;
        transform.position += dir * (moveSpeed * Time.deltaTime);
    }

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
}
