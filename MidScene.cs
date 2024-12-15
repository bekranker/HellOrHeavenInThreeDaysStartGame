using UnityEngine;
using UnityEngine.SceneManagement;

public class MidScene : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("menu");
        }
    }
}
