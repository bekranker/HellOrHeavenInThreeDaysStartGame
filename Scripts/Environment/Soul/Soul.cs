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
    private SoulType D_SoulType;
    public event Action OnClick;
    public event Action OnHover;
    public event Action OnExitHover;

    [SerializeField] private float _Speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _canClickable;

    void Awake() => _canClickable = true;
    public SoulType GetSoulType() => D_SoulType;
    private void Start()
    {
        _spriteRenderer.sprite = D_SoulType.BackOY;
        Harmony();

    }
    public void OnClickEvent()
    {
        if (!_canClickable) return;
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
    public void Init(SoulType type, Transform from, Transform to, CV cv)
    {
        DOTween.Kill(transform);
        transform.position = from.position;
        D_SoulType = type;
        transform.DOMove(to.position, _Speed).SetEase(Ease.Linear);
        _cv = cv;
    }
    private Tween Harmony()
    {
        return _spriteRenderer.transform.DOLocalMove(Vector3.down * .1f, .8f).OnComplete(() =>
        {
            _spriteRenderer.transform.DOLocalMove(Vector3.zero, .8f).SetEase(Ease.InOutSine).OnComplete(() => Harmony());
        }).SetEase(Ease.InOutSine);
    }
    public void OnHoverEnter()
    {
        OnHover?.Invoke();
    }

    public void OnHoverExit()
    {
        OnExitHover?.Invoke();
    }
}