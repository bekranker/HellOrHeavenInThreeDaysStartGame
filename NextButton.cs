using System;
using UnityEngine;

public class NextButton : MonoBehaviour, Interaction
{
    [SerializeField] private PlayerHandler _PlayerHandler;
    public event Action OnClick;
    public void OnClickEvent()
    {
        OnClick?.Invoke();
        Next();
    }
    public void Next()
    {
        _PlayerHandler.GetNewSoul();
    }
}
