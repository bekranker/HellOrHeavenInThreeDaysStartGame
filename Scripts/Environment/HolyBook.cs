using System;
using UnityEngine;

public class HolyBook : MonoBehaviour, Interaction
{
    public event Action OnClick;
    [SerializeField] private GameObject _HolyBook;
    public void OnClickEvent()
    {
        _HolyBook.SetActive(true);
        OnClick?.Invoke();
    }
    public void CloseBook() => _HolyBook.SetActive(false);


}