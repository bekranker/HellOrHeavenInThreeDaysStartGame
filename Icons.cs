using UnityEngine;
using UnityEngine.EventSystems;

public class Icons : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private string _toolTip;
    //we will spawn that prefab and drag it where we want
    [SerializeField] private IconItself _HoldingIcon;
    [SerializeField] private ToolTip _ToolTip;
    [SerializeField] private IconHandler _IconHandler;
    [SerializeField] private Transform _Parent;

    public void OnPointerClick(PointerEventData eventData)
    {
        IconItself tempIcon = _IconHandler.SetSelectedObject(Instantiate(_HoldingIcon));
        tempIcon.transform.SetParent(_Parent);
        tempIcon.gameObject.SetActive(false);
    }
}
