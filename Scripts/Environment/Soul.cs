using System;
using UnityEngine;

public class Soul : MonoBehaviour, Interaction
{
    private CameraHandler _cameraHandler;
    public event Action OnClick;

    void Start()
    {
        _cameraHandler = FindAnyObjectByType<CameraHandler>();
    }
    public void OnClickEvent()
    {
        _cameraHandler.CameraSwitch();
        OnClick?.Invoke();
    }
}