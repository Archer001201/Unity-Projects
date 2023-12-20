using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once ConvertToConstant.Global
    public static float bottomY = -20f;
    private ApplePicker _apScript;

    private void Start()
    {
        if (Camera.main != null) _apScript = Camera.main.GetComponent<ApplePicker>();
    }

    private void Update()
    {
        // ReSharper disable once InvertIf
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            _apScript.AppleDestroyed();
        }
    }
}
