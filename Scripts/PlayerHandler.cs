using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [Header("---Mitzvahes and Sins")]
    [SerializeField] private List<Mitzvah> _Mitzvahes = new();
    [SerializeField] private List<Sin> _Sins = new();
    [Header("---Prefab and Components")]
    [SerializeField] private Soul _SoulPrefab;
    [Header("---Props")]
    [SerializeField] private Transform _From, _To;
    private Pool<Soul> _Pool;

    void Start()
    {
        _Pool = new();
        _Pool.Spawn(_SoulPrefab, 10);
    }
    // giving me random data including random Sin and Mitzhaves;
    public SoulType GetRandomSoulData()
    {
        if (_Sins.Capacity <= 0 || _Mitzvahes.Capacity <= 0)
        {
            Debug.Log("Sins Capacity: " + _Sins.Capacity + "\n" + "Mitzhaves Capacity: " + _Mitzvahes.Capacity);
            return null;
        }


        int randomIndexM = Random.Range(0, _Mitzvahes.Capacity);
        int randomIndexS = Random.Range(0, _Sins.Capacity);

        SoulType tempSoul = SoulType.CreateInstance<SoulType>();
        tempSoul.Mitzvahs.Add(_Mitzvahes[randomIndexM]);
        tempSoul.Sins.Add(_Sins[randomIndexS]);

        _Mitzvahes.RemoveAt(randomIndexM);
        _Sins.RemoveAt(randomIndexS);

        return tempSoul;
    }
    //returning Soul class;
    public Soul GetNewSoul()
    {
        Soul tempSoul = _Pool.GetFromPool(_SoulPrefab);
        tempSoul.Init(GetRandomSoulData(), _From, _To);
        return tempSoul;
    }
}