using UnityEngine;
using DG.Tweening;


public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform _to;
    [SerializeField, Range(0, 10)] private float _Speed;


    public void CameraSwitch()
    {
        DOTween.Kill(transform);
        transform.DOMove(_to.position, _Speed).SetEase(Ease.OutBack);
    }

}