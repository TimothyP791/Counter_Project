using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isDragging = false;
    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        // Calculate offset between object position and mouse position
        offset = transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    

    void Update()
    {
        if (isDragging)
        { 
            zCoord = Mathf.Clamp(zCoord, 5f, 10f); // Adjust min/max as needed

            // Update position
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord; // Maintain object's z position
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}

