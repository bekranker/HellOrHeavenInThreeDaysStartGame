using DG.Tweening;
using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private CanvasGroup _CanvasGroup;
    [SerializeField] private float _Speed;
    [SerializeField] private TMP_Text _toolText;



    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1;
        transform.position = mousePos;
    }

    public void Show(string tip)
    {
        DOTween.Kill(_CanvasGroup);
        _CanvasGroup.DOFade(1, _Speed);
        _toolText.text = tip;
    }
    public void UnShow()
    {
        DOTween.Kill(_CanvasGroup);
        _CanvasGroup.DOFade(0, _Speed);
    }
}
