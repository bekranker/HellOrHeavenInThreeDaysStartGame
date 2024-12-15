using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
public class PlayerHandler : MonoBehaviour
{
    [Header("---Mitzvahes and Sins")]
    [SerializeField] private List<SoulType> _SoulType;
    [Header("---Prefab and Components")]
    [SerializeField] private DayCycle _DayCycle;
    [SerializeField] private Clock _Clock;
    [SerializeField] private CV _cv;
    [SerializeField] private Soul _SoulPrefab;
    [SerializeField] private List<Jugment> _Jugment;
    [Header("---Props")]
    [SerializeField] private Transform _From, _To;
    private Pool<Soul> _Pool;
    private Soul _currentSoul;
    private int _playerCount;
    public event Action OnNext;


    void Start()
    {
        _Pool = new();
        _Pool.Spawn(_SoulPrefab, 10);
        _SoulType = _SoulType.Where(item => !PlayerPrefs.HasKey(item.name)).ToList();
    }
    void OnEnable()
    {
        _Jugment[0].OnSelectGate += SetNullSelection;
        _Jugment[1].OnSelectGate += SetNullSelection;


    }
    void OnDisable()
    {
        _Jugment[0].OnSelectGate -= SetNullSelection;
        _Jugment[1].OnSelectGate -= SetNullSelection;
    }
    public int GetPlayerCount() => _playerCount;
    public void SetPlayerCount(int v) => _playerCount = v;
    private void SetNullSelection(string v)
    {
        _currentSoul = null;
    }
    public Soul GetCurrentSoul() => _currentSoul;
    // giving me random data including random Sin and Mitzhaves;
    private SoulType GetRandomSoulData()
    {
        if (_SoulType.Count <= 0)
        {
            Debug.Log("Soul Type Count: " + _SoulType.Count);
        }
        int randomIndex = Random.Range(0, _SoulType.Count);
        SoulType tempSoultType = _SoulType[randomIndex];
        _SoulType.RemoveAt(randomIndex);
        return tempSoultType;
    }
    //returning Soul class;
    public Soul GetNewSoul()
    {
        if (!_Clock.DayStart)
        {
            _DayCycle.StartDay();
        }
        if (_currentSoul != null)
        {
            Debug.Log("Current Soul is full, select a Gate");
            return null;
        }

        SetPlayerCount(_playerCount++);
        OnNext?.Invoke();
        _currentSoul = _Pool.GetFromPool(_SoulPrefab);
        _currentSoul.Init(GetRandomSoulData(), _From, _To, _cv);
        return _currentSoul;
    }
    public void MoveToGate(Vector3 selectedGatePosition) => GetCurrentSoul().MoveToGate(selectedGatePosition);
}