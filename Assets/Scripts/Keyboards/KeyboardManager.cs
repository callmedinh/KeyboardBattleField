using System;
using System.Collections.Generic;
using DefaultNamespace;
using Keyboards;
using UnityEngine;

public class KeyboardManager : Singleton<KeyboardManager>
{
    public List<KeyController> keyControllers;
    public static string LastKeyPressed;

    protected override void Awake()
    {
        base.Awake();
        var objs = FindObjectsByType<KeyController>(FindObjectsSortMode.None);
        foreach (var obj in objs)
        {
            keyControllers.Add(obj);
        }
    }

    public Vector2 GetPositionOfKey(string displayName)
    {
        foreach (var keyController in keyControllers)
        {
            if (keyController.keySo != null && keyController.keySo.keyName == displayName)
            {
                keyController.SetKeyState(true);
                return keyController.transform.position;
            }
        }
        return Vector2.zero;
    }
}