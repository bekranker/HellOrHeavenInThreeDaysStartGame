using UnityEngine;
using UnityEngine.EventSystems;

public class Icons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _toolTip;
    //we will spawn that prefab and drag it where we want
    [SerializeField] private GameObject _HoldingIcon;
    [SerializeField] private ToolTip _ToolTip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _ToolTip.Show(_toolTip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _ToolTip.UnShow();
    }
}
