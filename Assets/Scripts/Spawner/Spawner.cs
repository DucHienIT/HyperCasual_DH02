using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : DucHienMonoBehaviour
{
    [SerializeField] protected Transform holder;
    public Transform Holder => holder;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjects;

    [SerializeField] protected int spawnedCount = 0;

    public int SpawnedCount { get { return spawnedCount; } }




    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = this.transform.Find("Prefabs");
        foreach (Transform child in prefabObj)
        {
            this.prefabs.Add(child);
        }
        this.HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform child in this.prefabs)
        {
            child.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {

        Transform prefab = this.GetprefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogError("Prefab " + prefabName + " not found!");
            return null;
        }

        return this.Spawn(prefab, position, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {

        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(position, rotation);

        newPrefab.parent = this.holder;

        this.spawnedCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform child in this.poolObjects)
        {
            if (child.name == prefab.name)
            {
                this.poolObjects.Remove(child);
                return child;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform prefab)
    {
        this.poolObjects.Add(prefab);
        prefab.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    public virtual Transform GetprefabByName(string prefabName)
    {
        foreach (Transform child in this.prefabs)
        {
            if (child.name == prefabName) return child;
        }
        return null;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
