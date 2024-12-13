using UnityEngine;
using DG.Tweening;


public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform _to;
    [SerializeField] private float _Speed;


    public void CameraSwitch()
    {
        DOTween.Kill(transform);
        transform.DOMove(_to.position, _Speed);
    }

}