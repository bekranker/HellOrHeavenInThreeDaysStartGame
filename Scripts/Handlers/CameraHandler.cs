using UnityEngine;
using DG.Tweening;


public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform _to;
    [SerializeField, Range(0, 10)] private float _Speed;

    //I know it look shity... sorry for that :'( ;
    public void CameraSwitchLeft()
    {
        DOTween.Kill(transform);
        transform.DOMove(_to.position, _Speed);
    }
    public void CameraSwitchStartPosition()
    {
        DOTween.Kill(transform);
        transform.DOMove(new Vector3(0, 0, -10), _Speed);
    }
}