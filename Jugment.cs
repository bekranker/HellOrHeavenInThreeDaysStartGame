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
    //I know it look shity... sorry for that :'( ;

    public void Judgement(GateType gateType)
    {
        //find all sins and Mitzhases and sum them order's. look which one is bigger.;
        if (_PlayerHandler.GetCurrentSoul() == null)
        {
            Debug.Log("Select a Soul");
            return;
        }
        Soul executedSoul = _PlayerHandler.GetCurrentSoul();

        Mitzvah mitzvahes = executedSoul.GetSoulType().Mitzvahs;
        Sin sins = executedSoul.GetSoulType().Sins;
        int MitzhavesCount = 0;
        int sinCount = 0;


        if (mitzvahes != null)
        {
            MitzhavesCount = mitzvahes.Order;
        }
        if (sins != null)
        {
            sinCount = sins.Order;
        }
        //it has to go hell;
        if (sinCount > MitzhavesCount)
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

        _PlayerHandler.MoveToGate(_Gate.transform.position);
        OnSelectGate?.Invoke("Line: " + _PlayerHandler.GetPlayerCount().ToString() + "/3");
    }
}
