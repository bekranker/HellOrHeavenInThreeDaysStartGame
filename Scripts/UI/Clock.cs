using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;
public class Clock : MonoBehaviour
{
    private bool _shootEvent;
    [SerializeField] private float _dayTime = 6;
    private float _dayCounter;
    [SerializeField] private SceneTransaction _Sct;
    [SerializeField] private Transform _Arrow;
    [SerializeField] private Image _targetImage;
    private bool _isFinished;
    private event Action OnTimeFinish;
    public bool DayStart;


    void Start()
    {
        _dayCounter = _dayTime;
    }

    [ContextMenu("Start Arrow Animation")]
    public void ArrowAnimation()
    {
        StartCoroutine(FillImage());
        _Arrow.DOLocalRotate(new Vector3(0, 0, -360), _dayTime, RotateMode.FastBeyond360)
         .SetEase(Ease.Linear); // Sabit bir hızda döner
    }
    void Update()
    {
        if (!DayStart) return;
        if (_isFinished)
        {
            if (!_shootEvent)
            {
                _Sct.InstantExitLevel("Lose");
                CreateAudio.PlayAudio("fail");
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

    private IEnumerator FillImage()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 60)
        {
            elapsedTime += Time.deltaTime;
            float fill = Mathf.Clamp01(elapsedTime / 60); // 0 ile 1 arasında bir değer
            _targetImage.fillAmount = fill;
            yield return null; // Bir frame bekle
        }

        _targetImage.fillAmount = 1f; // Tam dolu yap
    }
}
