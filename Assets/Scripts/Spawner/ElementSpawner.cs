using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : Spawner
{
    private static ElementSpawner instance;
    public static ElementSpawner Instance { get { return instance; } }

    protected List<string> elements;

    [SerializeField] public static List<string> elementsInRound;


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

    public virtual void DespawnTwoElements(Transform element1, Transform element2)
    {
        if (element1 == null || element2 == null) return;
        this.Despawn(element1);
        this.Despawn(element2);
    }

    public virtual void SetElementsInRound(List<string> elements)
    {
        elementsInRound = elements;
    }

    public virtual Transform SpawnRandomElement(Vector3 positon)
    {
        if (elementsInRound == null || elementsInRound.Count == 0) return null;
        int randomIndex = Random.Range(0, elementsInRound.Count);
        Transform newElement = this.Spawn(elementsInRound[randomIndex], positon, Quaternion.identity);
        newElement.gameObject.SetActive(true);
        return newElement;
    }
}
