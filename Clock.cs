using UnityEngine;
using DG.Tweening;
using System;
public class Clock : MonoBehaviour
{
    private bool _shootEvent;
    public float _dayTime = 6;
    private float _dayCounter;
    [SerializeField] private Transform _Arrow;

    private bool _isFinished;
    private event Action OnTimeFinish;


    void Start()
    {
        _dayCounter = _dayTime;
        ArrowAnimation();
    }

    [ContextMenu("Start Arrow Animation")]
    public void ArrowAnimation()
    {
        _Arrow.DOLocalRotate(new Vector3(0, 0, -360), _dayTime, RotateMode.FastBeyond360)
         .SetEase(Ease.Linear); // Sabit bir hızda döner
    }
    void Update()
    {
        if (_isFinished)
        {
            if (!_shootEvent)
            {
                OnTimeFinish?.Invoke();
                _shootEvent = true;
            }
        }
        if (_dayCounter <= 0)
        {
            _isFinished = true;
        }
        else
        {
            SetTime(GetTime() - Time.deltaTime);
        }
    }
    public void SetTime(float v) => _dayCounter = v;
    public float GetTime() => _dayCounter;

}
