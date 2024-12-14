using System;
using UnityEngine;

public class Gate : MonoBehaviour, Interaction
{
    [SerializeField] private GateType _GateType;
    public event Action OnClick;

    public void OnClickEvent()
    {
        OnClick?.Invoke();
    }
    void Judgement()
    {
        //find all sins and Mitzhases and sum them order's. look which one is bigger.

    }

}

public enum GateType
{
    Hell,
    Heaven
}