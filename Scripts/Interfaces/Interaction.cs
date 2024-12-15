using System;
using UnityEngine;

public interface Interaction
{
    event Action OnHover, OnExitHover;
    void OnClickEvent();
    void OnHoverEnter();
    void OnHoverExit();
}
