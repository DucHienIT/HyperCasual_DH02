using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableGem : DucHienMonoBehaviour
{
    [SerializeField] private bool isDragging = false;
    [SerializeField] private Vector3 startPositon;
    [SerializeField] private Vector3 offset;

    protected virtual void OnMouseDown()
    {
        isDragging = true;
        startPositon = this.transform.parent.position;
        offset = startPositon - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    protected virtual void OnMouseUp()
    {
        isDragging = false;
        this.transform.parent.position = startPositon;
    }

    protected virtual void Update()
    {
        if (isDragging)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            transform.parent.position = currentPosition;
        }
    }
}
