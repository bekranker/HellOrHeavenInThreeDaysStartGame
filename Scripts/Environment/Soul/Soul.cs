using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


/* -----------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------
-----------------Sorry For Netsy Code;-----------------
-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------*/

public class Soul : MonoBehaviour, Interaction
{
    private CV _cv;
    private CameraHandler _cameraHandler;
    private SoulType D_SoulType;
    public event Action OnClick;
    [SerializeField] private float _Speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _canClickable;

    void Awake() => _canClickable = true;
    public SoulType GetSoulType() => D_SoulType;
    public void OnClickEvent()
    {
        if (!_canClickable) return;
        _cameraHandler.CameraSwitchLeft();
        ExecuteCV();
        OnClick?.Invoke();
    }
    private void ExecuteCV()
    {
        _cv.gameObject.SetActive(true);
        _cv.SetCurrentSoulType(D_SoulType);
        _cv.SetDatas();
        _cv.OpenMe();
    }
    public void MoveToGate(Vector3 to)
    {
        _canClickable = false;
        DOTween.Kill(transform);
        transform.DOMove(to, _Speed).OnComplete(() =>
        {
            _spriteRenderer.DOFade(0, _Speed);
        });
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