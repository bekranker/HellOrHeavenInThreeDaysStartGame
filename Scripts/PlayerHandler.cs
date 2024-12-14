using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [Header("---Mitzvahes and Sins")]
    [SerializeField] private List<Mitzvah> _Mitzvahes = new();
    [SerializeField] private List<Sin> _Sins = new();
    [Header("---Prefab and Components")]
    [SerializeField] private CV _cv;
    [SerializeField] private Soul _SoulPrefab;
    [SerializeField] private CameraHandler _cameraHandler;
    [Header("---Props")]
    [SerializeField] private Transform _From, _To;
    private Pool<Soul> _Pool;
    private Soul _currentSoul;

    void Start()
    {
        _Pool = new();
        _Pool.Spawn(_SoulPrefab, 10);
    }
    public Soul GetCurrentSoul() => _currentSoul;
    // giving me random data including random Sin and Mitzhaves;
    public SoulType GetRandomSoulData()
    {
        if (_Sins.Capacity <= 0 || _Mitzvahes.Capacity <= 0)
        {
            Debug.Log("Sins Capacity: " + _Sins.Capacity + "\n" + "Mitzhaves Capacity: " + _Mitzvahes.Capacity);
            return null;
        }


        SoulType tempSoul = SoulType.CreateInstance<SoulType>();

        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            int randomIndexM = Random.Range(0, _Mitzvahes.Capacity);
            int randomIndexS = Random.Range(0, _Sins.Capacity);

            tempSoul.Mitzvahs.Add(_Mitzvahes[randomIndexM]);
            tempSoul.Sins.Add(_Sins[randomIndexS]);

            tempSoul.Memories.Add(_Mitzvahes[randomIndexM].MitzvahLine);
            tempSoul.Memories.Add(_Sins[randomIndexS].SinLine);

            _Mitzvahes.RemoveAt(randomIndexM);
            _Sins.RemoveAt(randomIndexS);
        }


        return tempSoul;
    }
    //returning Soul class;
    public Soul GetNewSoul()
    {
        _currentSoul = _Pool.GetFromPool(_SoulPrefab);
        _currentSoul.Init(GetRandomSoulData(), _From, _To, _cameraHandler, _cv);
        return _currentSoul;
    }
}