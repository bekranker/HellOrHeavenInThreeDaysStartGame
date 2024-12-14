using UnityEngine;
using DG.Tweening;


public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform _to;
    [SerializeField, Range(0, 10)] private float _Speed;

    private Vector3 _fromPosition;
    private bool _switch;

    void Start()
    {
        _fromPosition = transform.position;
    }
    //I know it look shity... sorry for that :'( ;
    public void CameraSwitch()
    {
        DOTween.Kill(transform);
        if (_switch)
        {
            transform.DOMove(_to.position, _Speed).SetEase(Ease.OutBack);
        }
        else
        {
            transform.DOMove(_fromPosition, _Speed).SetEase(Ease.OutBack);
        }
        _switch = !_switch;
    }

}