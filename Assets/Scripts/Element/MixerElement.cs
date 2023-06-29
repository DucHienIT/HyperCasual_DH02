using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerElement : DucHienMonoBehaviour
{
    private static MixerElement instance;
    public static MixerElement Instance => instance;

    [SerializeField] protected List<ElementSO> elements;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListElements();
    }
    protected virtual void LoadListElements()
    {
        this.elements = new List<ElementSO>();
        foreach (ElementSO element in Resources.LoadAll<ElementSO>("Elements"))
        {
            this.elements.Add(element);
        }
    }

    public virtual bool MixTwoElements(Transform element1, Transform element2)
    {
        if (element1 == null || element2 == null) return false;
        string elementAfterMix = elementCanMix(element1, element2);
        if (elementAfterMix == null) return false;
        Transform newElement = ElementSpawner.Instance.Spawn(elementAfterMix, element2.position, Quaternion.identity);
        newElement.gameObject.SetActive(true);
        ElementSpawner.Instance.DespawnTwoElements(element1, element2);
        return true;
    }

    protected virtual string elementCanMix(Transform element1, Transform element2)
    {
        if (element1 == null || element2 == null) return null;
        foreach (ElementSO element in this.elements)
        {
            if (element.element_1 == null || element.element_2 == null) continue;
            if (element.element_1.name == element1.name && element.element_2.name == element2.name)
            {
                return element.name;
            }
            if (element.element_1.name == element2.name && element.element_2.name == element1.name)
            {
                return element.name;
            }
        }
        return null;
    }

}
