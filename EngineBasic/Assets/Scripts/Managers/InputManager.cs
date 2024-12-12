using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    private bool _mousePressed = false;

    public void OnUpdate()
    {
        OnUpdateKeyAction();
        OnUpdateMouseAction();
    }

    private void OnUpdateKeyAction()
    {
        if (Input.anyKey)
            KeyAction?.Invoke();
    }

    private void OnUpdateMouseAction()
    {
        if (MouseAction == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            MouseAction.Invoke(Define.MouseEvent.Press);
            _mousePressed = true;
        }
        else
        {
            if (_mousePressed)
                MouseAction.Invoke(Define.MouseEvent.Click);
            _mousePressed = false;
        }
    }
}
