using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public event EventHandler<OnChangeValueArgs> OnChangeValue;
    public class OnChangeValueArgs : EventArgs
    {
        public bool isTabClicked;
    }
    public event EventHandler OnUptime;
    public event EventHandler OnDownTime;
    public Vector2 Looking => _lookingVector2;

    //private value
    private Vector2 _lookingVector2;

    private UserInputSystem _userInputSystem;

    private bool _isChangeValue = false;
    private void Awake()
    {
        Instance = this;
        _userInputSystem = new UserInputSystem();
    }

    private void Start()
    {
        //looking mouse rotation
        _userInputSystem.Input.LookingRotation.started += OnLookingRotation;
        _userInputSystem.Input.LookingRotation.performed += OnLookingRotation;
        _userInputSystem.Input.LookingRotation.canceled += OnLookingRotation;
        //escape button
        _userInputSystem.Input.Escape.started += OnCursorHandle;
        //Change value button/tab
        _userInputSystem.Input.OpenChangeValue.started += OnChangeValueClicked;
        //UpTime
        _userInputSystem.Input.ChangeTime_Up.started += OnRightArrowClicked;
        //DownTime
        _userInputSystem.Input.ChangeTime_Down.started += OnLeftArrowClicked;

        //hide mouse cursor
        HideCursor();
    }

    
    private void OnLookingRotation(InputAction.CallbackContext ctx)
    {
        bool canRotate = Cursor.visible;

        if (!canRotate) _lookingVector2 = ctx.ReadValue<Vector2>();
    }

    private void OnCursorHandle(InputAction.CallbackContext ctx)
    {
        if (_isChangeValue) return;
        if (Cursor.visible) HideCursor();
        else ShowCursor();
    }

    private void OnChangeValueClicked(InputAction.CallbackContext ctx)
    {
        _isChangeValue = !_isChangeValue;
        OnChangeValue?.Invoke(this, new OnChangeValueArgs() { 
                isTabClicked = _isChangeValue
            });

        if (_isChangeValue) ShowCursor();
        else HideCursor();

    }

    private void OnRightArrowClicked(InputAction.CallbackContext ctx)
    {
        OnUptime?.Invoke(this, EventArgs.Empty);
    }
    private void OnLeftArrowClicked(InputAction.CallbackContext ctx)
    {
        OnDownTime?.Invoke(this, EventArgs.Empty);
    }

    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void HideAfterChange()
    {
        HideCursor();
    }
    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    private void OnDestroy()
    {
        //looking mouse rotation
        _userInputSystem.Input.LookingRotation.started -= OnLookingRotation;
        _userInputSystem.Input.LookingRotation.performed -= OnLookingRotation;
        _userInputSystem.Input.LookingRotation.canceled -= OnLookingRotation;
        //escape button
        _userInputSystem.Input.Escape.started -= OnCursorHandle;
    }
    private void OnEnable()
    {
        _userInputSystem.Enable();
    }
    private void OnDisable()
    {
        _userInputSystem.Disable();
    }
}
