using System;
using UnityEngine;

public class Gate : MonoBehaviour, Interaction
{
    [Header("---Components")]
    [SerializeField] private PlayerHandler _PlayerHandler;
    [SerializeField] private GateType _GateType;

    [Header("---Props")]

    [SerializeField] private Sprite _changeTo;
    [SerializeField] private SpriteRenderer _SpriteRenderer;
    private Sprite _startSprite;
    public event Action<GateType> OnClick;
    public event Action OnHover;
    public event Action OnExitHover;


    void Start()
    {
        _startSprite = _SpriteRenderer.sprite;
    }

    public void OnClickEvent()
    {

        OnClick?.Invoke(_GateType);
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

public enum GateType
{
    Hell,
    Heaven
}