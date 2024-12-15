using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;
public class MemoriesSide : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private IconHandler _Icons;
    [SerializeField] private TMP_Text _myText;
    [SerializeField] private Color _drawedColor;
    [SerializeField] private Transform _to;
    [SerializeField] private List<Jugment> _Jugments = new();
    private bool _can;

    void OnEnable()
    {
        _Jugments[0].OnSelectGateForResetUI += ResetTheUI;
        _Jugments[1].OnSelectGateForResetUI += ResetTheUI;
    }
    void OnDisable()
    {
        _Jugments[0].OnSelectGateForResetUI -= ResetTheUI;
        _Jugments[1].OnSelectGateForResetUI -= ResetTheUI;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_can) return;
        print("saUIO");
        if (_Icons.GetSelectedObject() != null)
        {
            _Icons.Effect(_to.position);
            _myText.color = _drawedColor;
            _myText.fontStyle = FontStyles.Strikethrough;
            _Icons.SetSelectedObject(null);
            _can = true;
        }
    }
    public void ResetTheUI()
    {
        _myText.fontStyle = FontStyles.Normal;
        _myText.color = Color.white;
    }

}
