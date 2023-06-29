using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableElement : DucHienMonoBehaviour
{
    [SerializeField] private bool isDragging = false;
    [SerializeField] private Vector3 startPositon;
    [SerializeField] private Vector3 offset;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected bool isOnTrigger = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        Debug.Log("Load Sphere Collider: " + transform.name, gameObject);
    }

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

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (isDragging == true)
        {
            bool SuccessMix = MixerElement.Instance.MixTwoElements(this.transform.parent, other.transform.parent);
            if (!SuccessMix) return; 
            ElementSpawner.Instance.SpawnRandomElement(startPositon);
            isDragging = false;
        }


    }
}
