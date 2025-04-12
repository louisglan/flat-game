using UnityEngine;
using System;

public class MouseDetect : MonoBehaviour
{
    public int objectIndex;
    public Action<int> onMouseEnter;
    void OnMouseEnter()
    {
        onMouseEnter?.Invoke(objectIndex);
    }
}