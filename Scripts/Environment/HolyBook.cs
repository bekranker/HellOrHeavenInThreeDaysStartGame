using System;
using System.Collections.Generic;
using UnityEngine;

public class HolyBook : MonoBehaviour, Interaction
{
    public event Action OnClick;
    [SerializeField] private GameObject _HolyBook;
    [SerializeField] private List<string> _TitlesMitzvahs = new();
    [SerializeField] private List<string> _TitlesSins = new();
    public Dictionary<int, string> Mitzvahs = new();
    public Dictionary<int, string> Sins = new();

    void Start()
    {
        SetDictionaries();
    }
    public void SetDictionaries()
    {
        for (int i = 0; i < 6; ++i)
        {
            Mitzvahs.Add(i, _TitlesMitzvahs[i]);
            Sins.Add(i, _TitlesSins[i]);
        }
    }
    public void OnClickEvent()
    {
        _HolyBook.SetActive(true);
        OnClick?.Invoke();
    }

    public void CloseBook() => _HolyBook.SetActive(false);
}