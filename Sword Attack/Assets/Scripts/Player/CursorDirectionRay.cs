using UnityEngine;

public class CursorDirectionRay : MonoBehaviour
{
    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = mousePosition - (Vector2)transform.position; 
        Debug.DrawLine(transform.position, mousePosition, Color.red);
    }
}