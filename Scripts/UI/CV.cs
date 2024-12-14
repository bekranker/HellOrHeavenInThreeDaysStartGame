using System;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class CV : MonoBehaviour
{
    [SerializeField] private float _Speed;
    [SerializeField] private TMP_Text _FirstSentences;
    [SerializeField] private TMP_Text _SecondSentences;
    [SerializeField] private TMP_Text _Name;
    [SerializeField] private Image _Picture;
    [SerializeField] private Transform _To;
    private SoulType _currentSoulType;
    [SerializeField] private CameraHandler _CameraHandler;
    [SerializeField] private GameObject _closeButton;

    public void SetCurrentSoulType(SoulType v) => _currentSoulType = v;
    public SoulType GetCurrentSoulType() => _currentSoulType;
    //writing current clicked soul's memories.;
    public void SetDatas()
    {
        DOTween.Kill(transform);
        transform.DOMove(_To.position, _Speed);
        _FirstSentences.text += _currentSoulType.Memories[0];
        _SecondSentences.text += _currentSoulType.Memories[1];
    }
    //closing CV with pressing full screen button;
    public void CloseMe()
    {
        _CameraHandler.CameraSwitchStartPosition();
        _closeButton.SetActive(false);
        gameObject.SetActive(false);
    }
    public void OpenMe()
    {
        _CameraHandler.CameraSwitchLeft();
        _closeButton.SetActive(true);
    }
}