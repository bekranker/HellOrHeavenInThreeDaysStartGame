using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;


public class SoulLine : MonoBehaviour, ITextSet
{
    [SerializeField] private PlayerHandler _PlayerHandler;
    [SerializeField] private TMP_Text _LineTMP;
    [SerializeField] private float _Speed;
    private Vector3 _startScale;

    [SerializeField] private SceneTransaction _Sct;

    void OnEnable()
    {
        _PlayerHandler.OnNext += IncreasePlayer;
    }
    void OnDisable()
    {
        _PlayerHandler.OnNext -= IncreasePlayer;
    }

    void Start()
    {
        _startScale = transform.localScale;
        textEffect("Line: 0/3");
    }
    private void IncreasePlayer()
    {
        _PlayerHandler.SetPlayerCount(_PlayerHandler.GetPlayerCount() + 1);
        SetText("Line: " + _PlayerHandler.GetPlayerCount().ToString() + "/3");
        if (_PlayerHandler.GetPlayerCount() >= 3)
        {
            //other day
            _Sct.ExitLevel("GamePlay");
        }
    }
    public void SetText(string v)
    {
        textEffect(v);
        _LineTMP.transform.DOShakeScale(_Speed, .3f, 25).OnComplete(() =>
        {
            _LineTMP.transform.localScale = _startScale;
        });
    }

    public void textEffect(string v)
    {
        _LineTMP.text = v;
    }
}
