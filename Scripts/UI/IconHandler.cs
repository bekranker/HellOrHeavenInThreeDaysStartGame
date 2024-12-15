using DG.Tweening;
using UnityEngine;

public class IconHandler : MonoBehaviour
{
    private IconItself _selectedObject;

    public IconItself SetSelectedObject(IconItself v)
    {
        _selectedObject = v;
        return _selectedObject;
    }
    public void Effect(Vector3 pos)
    {
        if (_selectedObject == null) return;
        _selectedObject.gameObject.SetActive(true);
        _selectedObject.transform.position = pos;
        _selectedObject.transform.localScale *= 3;
        _selectedObject.transform.DOScale(Vector3.one / 1.1f, .4f).SetEase(Ease.OutFlash).OnComplete(() =>
        {
            //ScreenShake
        });
    }
    public IconItself GetSelectedObject() => _selectedObject;
}
