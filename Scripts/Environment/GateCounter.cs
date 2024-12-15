using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Threading;



public class GateCounter : MonoBehaviour, ITextSet
{
    [SerializeField] private float _Speed;
    [SerializeField] private TMP_Text _HellCounterTMP;
    [SerializeField] private Gate _Gate;
    [SerializeField] private PlayerHandler _PlayerHandler;
    private Vector3 _startScale;
    private int _count = 0;


    void OnEnable()
    {
        _Gate.OnClick += IncreaseCount;
    }
    void OnDisable()
    {
        _Gate.OnClick -= IncreaseCount;
    }
    void Start()
    {
        _startScale = _HellCounterTMP.transform.localScale;
        textEffect("0");
    }
    private void IncreaseCount(GateType gateType)
    {
        if (_PlayerHandler.GetCurrentSoul() == null) return;
        _count++;
        SetText(_count.ToString());
    }
    public void SetText(string v)
    {
        textEffect(v);
        _HellCounterTMP.transform.DOShakeScale(_Speed, _HellCounterTMP.transform.localScale.x, 25).OnComplete(() =>
        {
            _HellCounterTMP.transform.localScale = _startScale;
        });
    }

    public void textEffect(string v)
    {
        _HellCounterTMP.text = v;
    }
}
