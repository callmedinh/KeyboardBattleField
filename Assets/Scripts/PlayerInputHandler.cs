using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _attackAction;
    private Vector2 MoveInput { get; set; }
    public bool JumpPressed { get; private set; }
    private PlayerController _playerController;
    public event Action<string> OnAttackKeyPressed;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _attackAction = InputSystem.actions.FindAction("Attack");
        _attackAction.performed += HandleAttackInput;
    }

    private void HandleAttackInput(InputAction.CallbackContext obj)
    {
        string keyName = obj.control.name;
        OnAttackKeyPressed?.Invoke(keyName);
        Debug.Log(keyName);
        KeyboardManager.LastKeyPressed = keyName;
    }

    private void Update()
    {
        _playerController.jump = _jumpAction.WasPressedThisFrame();
        _playerController.moveInput = _moveAction.ReadValue<Vector2>();
        _playerController.isAttacking = _attackAction.WasPressedThisFrame();
    }

}