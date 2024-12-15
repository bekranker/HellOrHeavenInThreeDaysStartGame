using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HolyBook : MonoBehaviour, Interaction
{
    public event Action OnClick;
    public event Action OnHover;
    public event Action OnExitHover;
    [Header("---Props")]

    [SerializeField] private Sprite _changeTo;
    [SerializeField] private SpriteRenderer _SpriteRenderer;
    private Sprite _startSprite;
    [SerializeField] private GameObject _HolyBook;
    [SerializeField] private List<string> _TitlesMitzvahs = new();
    [SerializeField] private List<string> _TitlesSins = new();
    public Dictionary<int, string> Mitzvahs = new();
    public Dictionary<int, string> Sins = new();
    [SerializeField] private List<TMP_Text> _MitzvahsTMPs = new();
    [SerializeField] private List<TMP_Text> _SinsTMPs = new();

    void Start()
    {
        SetDictionaries();
        _startSprite = _SpriteRenderer.sprite;
    }
    public void SetDictionaries()
    {
        for (int i = 0; i < 6; i++)
        {
            Mitzvahs.Add(i, _TitlesMitzvahs[i]);
            Sins.Add(i, _TitlesSins[i]);
        }
        SwipeDictionaries.SwapRandomItems(ref Mitzvahs, ref Sins);
        UpdateTexts();
    }
    private void UpdateTexts()
    {
        for (int i = 0; i < 6; i++)
        {
            _MitzvahsTMPs[i].text = $"{i + 1} {Mitzvahs[i]}";
            _SinsTMPs[i].text = $"{i + 1} {Sins[i]}";
        }
    }
    public void OnClickEvent()
    {
        _HolyBook.SetActive(true);
        OnClick?.Invoke();
    }
    public void CloseBook() => _HolyBook.SetActive(false);

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