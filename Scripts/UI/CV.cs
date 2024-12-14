using TMPro;
using UnityEngine;

public class CV : MonoBehaviour
{

    [SerializeField] private TMP_Text _SoulTMP;

    private SoulType _currentSoulType;

    public void SetCurrentSoulType(SoulType v) => _currentSoulType = v;
    public SoulType GetCurrentSoulType() => _currentSoulType;
    //writing current clicked soul's memories.
    public void SetDatas()
    {
        for (int i = 0; i < _currentSoulType.Memories.Count; i++)
        {
            _SoulTMP.text += _currentSoulType.Memories[i] + "\n";
        }
    }

}