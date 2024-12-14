using System;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, Interaction
{
    [Header("---Components")]
    [SerializeField] private PlayerHandler _PlayerHandler;
    [SerializeField] private GateType _GateType;


    public event Action OnClick;

    public void OnClickEvent()
    {
        OnClick?.Invoke();
        Judgement();
    }

    //I know it look shity... sorry for that :'( ;

    public void Judgement()
    {
        //find all sins and Mitzhases and sum them order's. look which one is bigger.;
        if (_PlayerHandler.GetCurrentSoul() == null)
        {
            Debug.Log("Select a Soul");
            return;
        }
        Soul executedSoul = _PlayerHandler.GetCurrentSoul();

        List<Mitzvah> Mitzvahes = executedSoul.GetSoulType().Mitzvahs;
        List<Sin> Sins = executedSoul.GetSoulType().Sins;
        int counterM = 0;
        int counterS = 0;


        if (Mitzvahes.Capacity != 0)
        {
            for (int i = 0; i < Mitzvahes.Count; i++)
            {
                counterM += Mitzvahes[i].Order;
            }
        }
        if (Sins.Capacity != 0)
        {
            for (int i = 0; i < Sins.Count; i++)
            {
                counterS += Sins[i].Order;
            }
        }
        //it has to go hell;
        if (counterS > counterM)
        {
            if (_GateType == GateType.Hell)
            {
                //Win
            }
            else
            {
                //Lose
            }
        }
        //it has to go heaven;
        else
        {
            if (_GateType == GateType.Hell)
            {
                //Lose
            }
            else
            {
                //Win
            }
        }
    }
}

public enum GateType
{
    Hell,
    Heaven
}