using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
public class DayCycle : MonoBehaviour, ITextSet
{

    [SerializeField] private TMP_Text _LineTMP;
    [SerializeField] private float _Speed;
    [SerializeField] private PlayerHandler _PlayerHandler;
    [SerializeField] private Clock _Clock;
    private int _day;
    private Vector3 _startScale;

    public event Action OnDayStart;

    void Start()
    {
        _startScale = transform.localScale;
        textEffect("Day " + GetDay());
        Invoke("Announcment", Random.Range(10, 50));
    }
    private void Announcment()
    {
        CreateAudio.PlayAudio("GetLinePlease", 1f);
    }
    public int GetDay()
    {
        if (PlayerPrefs.HasKey("Day") && !PlayerPrefs.HasKey("lose"))
        {
            return PlayerPrefs.GetInt("Day") + 1;
        }
        PlayerPrefs.DeleteKey("lose");
        return 1;
    }
    public void SetDay(int v)
    {
        _day = v;
        PlayerPrefs.SetInt("Day", v);
    }
    public void SetText(string v)
    {
        textEffect(v);
        _LineTMP.transform.DOShakeScale(_Speed, .3f, 25).OnComplete(() =>
        {
            _LineTMP.transform.localScale = _startScale;
        });
    }
    private void DayFinished()
    {
        //Win
        if (_PlayerHandler.GetPlayerCount() == 3 && _Clock.GetTime() >= 0)
        {
            //a black screen will Fade In when we win and then day will;
            Debug.Log("Day is over, you win the day");
        }
        //Lose
        else
        {
            //a black screen splash to screen and then main menu will open;
            Debug.Log("Day is over, you lose");
        }
    }
    public void StopDay()
    {
        _Clock.DayStart = false;
        DayFinished();
    }
    //call this when First Next button start;
    public void StartDay()
    {

        if (GetDay() == 3)
        {
            //end the game;
        }
        else
        {
            print("day start");
            _Clock.ArrowAnimation();
            _Clock.DayStart = true;
            SetDay(GetDay() + 1);
            OnDayStart?.Invoke();
        }
    }
    public void textEffect(string v)
    {
        _LineTMP.text = v;
    }
}
