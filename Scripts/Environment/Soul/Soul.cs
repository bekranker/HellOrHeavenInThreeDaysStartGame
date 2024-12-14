using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Soul : MonoBehaviour, Interaction
{
    private CV _cv;
    private CameraHandler _cameraHandler;
    private SoulType D_SoulType;
    public event Action OnClick;
    [SerializeField] private float _Speed;

    public void OnClickEvent()
    {
        _cameraHandler.CameraSwitch();
        ExecuteCV();
        OnClick?.Invoke();
    }
    private void ExecuteCV()
    {
        _cv.gameObject.SetActive(true);
        _cv.SetCurrentSoulType(D_SoulType);
        _cv.SetDatas();
    }
    public void Init(SoulType type, Transform from, Transform to, CameraHandler camHandler, CV cv)
    {
        _cameraHandler = camHandler;
        DOTween.Kill(transform);
        transform.position = from.position;
        D_SoulType = type;
        transform.DOMove(to.position, _Speed);
        _cv = cv;
    }
}