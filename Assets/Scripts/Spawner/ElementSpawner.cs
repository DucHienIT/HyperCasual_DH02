using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : Spawner
{
    private static ElementSpawner instance;
    public static ElementSpawner Instance { get { return instance; } }

    [SerializeField] public static List<string> elements;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadElements();
    }
    protected virtual void LoadElements()
    {
        if (elements != null) return;
        elements = new List<string>();
        foreach (Transform element in this.prefabs)
        {
            elements.Add(element.name);
        }   
    }

    protected override void Awake()
    {
        base.Awake();
        if (ElementSpawner.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        ElementSpawner.instance = this;
    }
}
