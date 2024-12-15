using UnityEngine;
using System.Collections.Generic;
using System;

public class Jugment : MonoBehaviour
{
    [Header("---Components")]
    [SerializeField] private PlayerHandler _PlayerHandler;
    [SerializeField] private Gate _Gate;
    [SerializeField] private HolyBook _HolyBook;

    public event Action<string> OnSelectGate;
    public event Action OnWrong;
    void OnEnable()
    {
        _Gate.OnClick += Judgement;
    }
    void OnDisable()
    {
        _Gate.OnClick -= Judgement;
    }
    //I know it look shity... sorry for that :'( ;


    //this func will call on click any gate
    public void Judgement(GateType gateType)
    {
        //find all jugments and Mitzhases and sum them order's. look which one is bigger.;
        if (_PlayerHandler.GetCurrentSoul() == null)
        {
            Debug.Log("Select a Soul");
            return;
        }
        Soul executedSoul = _PlayerHandler.GetCurrentSoul();

        string jugmentOne = executedSoul.GetSoulType().JugmentOne;
        string jugmentTwo = executedSoul.GetSoulType().JugmentTwo;
        int MitzhavesCount = 0;
        int sinCount = 0;



        Check(ref MitzhavesCount, ref sinCount, jugmentOne, _HolyBook.Mitzvahs, _HolyBook.Sins);
        Check(ref sinCount, ref MitzhavesCount, jugmentTwo, _HolyBook.Sins, _HolyBook.Mitzvahs);


        //It has to go heaven
        if (MitzhavesCount > sinCount)
        {
            //its wrong decision
            if (gateType == GateType.Hell)
            {
                OnWrong?.Invoke();
            }
            //Right decision
            else
            {
                Debug.Log("Right Decision");
            }
        }
        else if (MitzhavesCount < sinCount)
        {
            //Its right decision
            if (gateType == GateType.Hell)
            {
                Debug.Log("Right Decision");
            }
            //wrong
            else
            {
                OnWrong?.Invoke();
            }
        }

        _PlayerHandler.MoveToGate(_Gate.transform.position);
        OnSelectGate?.Invoke("Line: " + _PlayerHandler.GetPlayerCount().ToString() + "/3");
    }
    private void Check(ref int v, ref int v2, string myValue, Dictionary<int, string> dV, Dictionary<int, string> dV2)
    {
        foreach (KeyValuePair<int, string> item in dV)
        {
            if (item.Value == myValue)
            {
                v = item.Key;
                return;
            }
        }
        Check(ref v2, ref v, myValue, dV2, null);
    }
}
