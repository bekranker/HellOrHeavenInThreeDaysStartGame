using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Soul : MonoBehaviour, Interaction
{
    private CameraHandler _cameraHandler;
    public SoulType D_SoulType;

    public event Action OnClick;
    [SerializeField] private float _Speed;

    void Start()
    {
        _cameraHandler = FindAnyObjectByType<CameraHandler>();
    }
    public void OnClickEvent()
    {
        _cameraHandler.CameraSwitch();
        OnClick?.Invoke();
    }
    public void Init(SoulType type, Transform from, Transform to)
    {
        DOTween.Kill(transform);
        transform.position = from.position;
        D_SoulType = type;
        transform.DOMove(to.position, _Speed);
    }
}