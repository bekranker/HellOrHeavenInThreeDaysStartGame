using DG.Tweening;
using TMPro;
using UnityEngine;

public class DayCycle : MonoBehaviour, ITextSet
{
    [SerializeField] private TMP_Text _LineTMP;
    [SerializeField] private float _Speed;

    private int _day;
    private Vector3 _startScale;

    void Start()
    {
        _day = PlayerPrefs.GetInt("Day", 0);
        _startScale = transform.localScale;
        textEffect("Day " + _day);
    }
    public int GetDay() => _day;
    public void SetDay(int v) => _day = v;
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
