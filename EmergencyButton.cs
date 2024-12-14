using System;
using UnityEngine;

public class EmergencyButton : MonoBehaviour, Interaction
{
    public event Action OnClick;
    public void OnClickEvent()
    {
        OnClick?.Invoke();
    }
}