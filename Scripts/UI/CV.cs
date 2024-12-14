using System;
using TMPro;
using UnityEngine;
using DG.Tweening;


public class CV : MonoBehaviour
{
    [SerializeField] private float _Speed;
    [SerializeField] private TMP_Text _SoulTMP;
    [SerializeField] private Transform _To;
    private SoulType _currentSoulType;

    public void SetCurrentSoulType(SoulType v) => _currentSoulType = v;
    public SoulType GetCurrentSoulType() => _currentSoulType;
    //writing current clicked soul's memories.
    public void SetDatas()
    {
        transform.DOMove(_To.position, _Speed);
        for (int i = 0; i < _currentSoulType.Memories.Count; i++)
        {
            _SoulTMP.text += _currentSoulType.Memories[i] + "\n";
        }
    }

}