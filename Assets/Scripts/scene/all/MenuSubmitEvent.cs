using System;
using UnityEngine;

public class MenuSubmitEvent : MonoBehaviour
{
    public static event Action OnSubmit;

    public static void Trigger()
    {
        OnSubmit?.Invoke();
    }
}
