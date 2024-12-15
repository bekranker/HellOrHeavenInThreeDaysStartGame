using System;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class CV : MonoBehaviour
{
    [SerializeField] private TMP_Text _FirstSentences;
    [SerializeField] private TMP_Text _SecondSentences;
    [SerializeField] private TMP_Text _Name;
    [SerializeField] private TMP_Text _Job;
    [SerializeField] private TMP_Text _Sex;

    [SerializeField] private Image _Picture;
    [SerializeField] private Image _BigFrontPicture;

    private SoulType _currentSoulType;
    [SerializeField] private GameObject _closeButton;

    public void SetCurrentSoulType(SoulType v) => _currentSoulType = v;
    public SoulType GetCurrentSoulType() => _currentSoulType;


    //writing current clicked soul's memories.;
    public void SetDatas()
    {
        _FirstSentences.text = _currentSoulType.Memories[0];
        _SecondSentences.text = _currentSoulType.Memories[1];
        _Name.text = _currentSoulType.name;
        _Job.text = _currentSoulType.JobTitle;
        _Sex.text = _currentSoulType.Sex;
        _Picture.sprite = _currentSoulType.Picture;
        _BigFrontPicture.sprite = _currentSoulType.Front;
    }
    //closing CV with pressing full screen button;
    public void CloseMe()
    {
        _closeButton.SetActive(false);
        gameObject.SetActive(false);
    }
    public void OpenMe()
    {
        _closeButton.SetActive(true);
    }
}