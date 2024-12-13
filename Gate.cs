using System;
using UnityEngine;

public class Gate : MonoBehaviour, Interaction
{
    public event Action OnClick;

    public void OnClickEvent()
    {
        OnClick?.Invoke();
    }
}