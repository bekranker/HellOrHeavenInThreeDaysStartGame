using System;
using UnityEngine;

public class NextButton : MonoBehaviour, Interaction
{
    [SerializeField] private PlayerHandler _PlayerHandler;
    [Header("---Props")]

    [SerializeField] private Sprite _changeTo;
    [SerializeField] private SpriteRenderer _SpriteRenderer;
    private Sprite _startSprite;
    public event Action OnClick;
    public event Action OnHover;
    public event Action OnExitHover;

    void Start()
    {
        _startSprite = _SpriteRenderer.sprite;
    }
    public void OnClickEvent()
    {
        OnClick?.Invoke();
        Next();
    }
    public void Next()
    {
        _PlayerHandler.GetNewSoul();
    }

    public void OnHoverEnter()
    {
        _SpriteRenderer.sprite = _changeTo;
        OnHover?.Invoke();
    }

    public void OnHoverExit()
    {
        _SpriteRenderer.sprite = _startSprite;
        OnExitHover?.Invoke();
    }
}
