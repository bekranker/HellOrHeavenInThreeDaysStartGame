using UnityEngine;
using DG.Tweening;
using System.IO.Compression;


public class BackgroundSouls : MonoBehaviour
{
    [SerializeField] private Transform _to;
    [SerializeField] private Vector2 _speed;
    private Vector3 _startPos;
    [SerializeField] private Transform _SpriteRendererT;
    void Start()
    {
        _startPos = transform.position;
        LoopTween();
        DOVirtual.DelayedCall(Random.Range(.1f, 1f), () => { Harmony(); });
    }
    private void LoopTween()
    {
        DOVirtual.DelayedCall(Random.Range(3, 7), () =>
        {
            transform.DOMove(_to.position, Random.Range(_speed.x, _speed.y)).SetEase(Ease.Linear).OnComplete(() =>
            {
                LoopTween();
                transform.position = _startPos;
            });
        });
    }
    private Tween Harmony()
    {
        return _SpriteRendererT.DOLocalMove(Vector3.down * .3f, .8f).OnComplete(() =>
        {
            _SpriteRendererT.DOLocalMove(Vector3.zero, .8f).SetEase(Ease.InOutSine).OnComplete(() => Harmony());
        }).SetEase(Ease.InOutSine);
    }

}

