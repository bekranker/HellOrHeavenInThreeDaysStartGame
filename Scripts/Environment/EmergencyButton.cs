using System;
using UnityEngine;

public class EmergencyButton : MonoBehaviour, Interaction
{
    public event Action OnClick;
    public event Action OnHover;
    public event Action OnExitHover;

    public void OnClickEvent()
    {
        OnClick?.Invoke();
    }

    public void OnHoverEnter()
    {
        OnHover?.Invoke();
    }

    public void OnHoverExit()
    {
        OnExitHover?.Invoke();
    }
}