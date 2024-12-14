using System;
using UnityEngine;

public class Gate : MonoBehaviour, Interaction
{
    [Header("---Components")]
    [SerializeField] private PlayerHandler _PlayerHandler;
    [SerializeField] private GateType _GateType;


    public event Action<GateType> OnClick;

    public void OnClickEvent()
    {
        OnClick?.Invoke(_GateType);
    }

    //I know it look shity... sorry for that :'( ;


}

public enum GateType
{
    Hell,
    Heaven
}