using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HolyBook : MonoBehaviour, Interaction
{
    public event Action OnClick;
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
    }
    public void SetDictionaries()
    {
        for (int i = 0; i < 6; ++i)
        {
            Mitzvahs.Add(i, _TitlesMitzvahs[i]);
            Sins.Add(i, _TitlesSins[i]);
            _MitzvahsTMPs[i].text = i + "-) " + _TitlesMitzvahs[i];
            _SinsTMPs[i].text = i + "-) " + _TitlesSins[i];
        }
    }
    public void OnClickEvent()
    {
        _HolyBook.SetActive(true);
        OnClick?.Invoke();
    }

    public void CloseBook() => _HolyBook.SetActive(false);
}