using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
public class MemoriesSide : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private IconHandler _Icons;
    [SerializeField] private TMP_Text _myText;
    [SerializeField] private Color _drawedColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        print("saUIO");
        if (_Icons.GetSelectedObject() != null)
        {
            _Icons.Effect(transform.position);
            _myText.color = _drawedColor;
            _myText.fontStyle = FontStyles.Strikethrough;
            _Icons.SetSelectedObject(null);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
