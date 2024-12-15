using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private LayerMask _ClickableLayer;
    private RaycastHit2D _previousHit2D; // Önceki Raycast hit kaydı

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast(mousePos, Vector3.forward, 100, _ClickableLayer);

        // Eğer raycast bir collider'a çarptıysa
        if (hit2D.collider != null)
        {
            if (hit2D.collider.TryGetComponent(out Interaction interaction))
            {
                if (_previousHit2D.collider != hit2D.collider) // Eğer farklı bir objeye hover yapılıyorsa
                {
                    // Eski objeye Exit olayını çağır
                    if (_previousHit2D.collider != null &&
                        _previousHit2D.collider.TryGetComponent(out Interaction previousInteraction))
                    {
                        previousInteraction.OnHoverExit();
                    }

                    // Yeni objeye Hover olayını çağır
                    interaction.OnHoverEnter();
                }
            }
        }
        else if (_previousHit2D.collider != null) // Eğer artık bir objeye hover yapılmıyorsa
        {
            if (_previousHit2D.collider.TryGetComponent(out Interaction previousInteraction))
            {
                previousInteraction.OnHoverExit(); // Eski objeye Exit olayını çağır
            }
        }

        // Eğer tıklama algılanırsa
        if (Input.GetMouseButtonDown(0))
        {
            if (hit2D.collider != null)
            {
                if (hit2D.collider.TryGetComponent(out Interaction interaction))
                {
                    interaction.OnClickEvent();
                }
            }
        }

        // Önceki raycast hit'ini güncelle
        _previousHit2D = hit2D;
    }
}