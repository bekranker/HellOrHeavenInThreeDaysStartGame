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
    public event Action OnSelectGateForResetUI;

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
        int JugmentOneCount = 0;
        int JugmentTwoCount = 0;



        JugmentOneCount = Check(jugmentOne, _HolyBook.Mitzvahs, _HolyBook.Sins);
        JugmentTwoCount = Check(jugmentTwo, _HolyBook.Mitzvahs, _HolyBook.Sins);


        //It has to go heaven
        if (JugmentOneCount >= JugmentTwoCount)
        {
            //its wrong decision
            if (gateType == GateType.Hell)
            {
                OnWrong?.Invoke();
                CreateAudio.PlayAudio("cehennem", .5f);
            }
            //Right decision
            else
            {
                Debug.Log("Right Decision");
                CreateAudio.PlayAudio("cennet", .5f);
            }
        }
        else if (JugmentOneCount <= JugmentTwoCount)
        {
            //Its right decision
            if (gateType == GateType.Hell)
            {
                Debug.Log("Right Decision");
                CreateAudio.PlayAudio("cehennem", .5f);

            }
            //wrong
            else
            {
                OnWrong?.Invoke();
                CreateAudio.PlayAudio("cennet", .5f);

            }
        }

        _PlayerHandler.MoveToGate(_Gate.transform.position);
        OnSelectGate?.Invoke("Line: " + _PlayerHandler.GetPlayerCount().ToString() + "/3");
        OnSelectGateForResetUI?.Invoke();
    }
    private int Check(string myValue, Dictionary<int, string> dV, Dictionary<int, string> dV2)
    {
        foreach (KeyValuePair<int, string> item in dV)
        {
            if (item.Value == myValue)
            {
                return item.Key;
            }
        }
        foreach (KeyValuePair<int, string> item in dV2)
        {
            if (item.Value == myValue)
            {
                return item.Key;
            }
        }
        return 0;
    }
}
