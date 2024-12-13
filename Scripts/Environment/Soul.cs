using System;
using UnityEngine;

public class Soul : MonoBehaviour, Interaction
{

    public event Action OnClick;
    public void OnClickEvent()
    {
        OnClick?.Invoke();
    }
}