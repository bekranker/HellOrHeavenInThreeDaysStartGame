using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private LayerMask _ClickableLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(mousePos, Vector3.forward, 100, _ClickableLayer);

            if (hit2D.collider != null)
            {
                if (hit2D.collider.TryGetComponent(out Interaction interaction))
                {
                    interaction.OnClickEvent();
                }
            }
        }
    }
}
