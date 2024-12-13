using System;
using UnityEngine;

public class HolyBook : MonoBehaviour, Interaction
{
    public event Action OnClick;
    public void OnClickEvent()
    {
        OnClick?.Invoke();
    }
}