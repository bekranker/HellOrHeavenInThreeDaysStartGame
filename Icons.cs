using UnityEngine;
using UnityEngine.EventSystems;

public class Icons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _toolTip;
    //we will spawn that prefab and drag it where we want
    [SerializeField] private GameObject _HoldingIcon;

    public void OnPointerEnter(PointerEventData eventData)
    {

        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
