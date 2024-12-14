using UnityEngine;
using System.Collections.Generic;
using System;

public class Jugment : MonoBehaviour
{
    [Header("---Components")]
    [SerializeField] private PlayerHandler _PlayerHandler;
    [SerializeField] private Gate _Gate;

    public event Action<string> OnSelectGate;

    void OnEnable()
    {
        _Gate.OnClick += Judgement;
    }
    void OnDisable()
    {
        _Gate.OnClick -= Judgement;
    }
    public void Judgement(GateType gateType)
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
            if (gateType == GateType.Hell)
            {
                Debug.Log("we choose Hell");
                //Win
            }
            else
            {
                Debug.Log("we choose Heaven");

                //Lose
            }
            Debug.Log("it has to go heaven");

        }
        //it has to go heaven;
        else
        {
            if (gateType == GateType.Hell)
            {
                Debug.Log("we choose Hell\n");


                //Lose
            }
            else
            {
                Debug.Log("we choose Heaven");

                //Win
            }
            Debug.Log("it has to go heaven");

        }

        OnSelectGate?.Invoke("Line: " + _PlayerHandler.GetPlayerCount().ToString() + "/3");
    }
}
