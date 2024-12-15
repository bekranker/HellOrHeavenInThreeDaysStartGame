using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class SceneTransaction : MonoBehaviour
{
    [SerializeField] private Image _Panel;
    [SerializeField, Range(0, 3)] private float _Speed;

    void Start()
    {
        OpenLevel();
    }
    public void OpenLevel()
    {
        DOTween.Kill(_Panel);
        _Panel.DOFade(0, _Speed);
    }
    public void ExitLevel(string sceneName)
    {
        DOTween.Kill(_Panel);
        _Panel.DOFade(1, _Speed).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
    public void InstantExitLevel(string sceneName)
    {
        _Panel.DOFade(1, .1f).OnComplete(() =>
        {
            DOVirtual.DelayedCall(2, () =>
            {
                SceneManager.LoadScene(sceneName);
            });
        });
    }
}
