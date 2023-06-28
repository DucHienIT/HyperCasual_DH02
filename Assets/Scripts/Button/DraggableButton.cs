using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableButton : DucHienMonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.Log("Load Button: " + transform.name, gameObject);
    }
    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
        Debug.Log("Add On Click Event: " + transform.name, gameObject);
    }
    protected virtual void OnClick()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        button.image.color = new Color(1f, 1f, 1f, 0.6f);
        button.interactable = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        button.transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        button.image.color = Color.white;
        button.interactable = true;
    }
}
