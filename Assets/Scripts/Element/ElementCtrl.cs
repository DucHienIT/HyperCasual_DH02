using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCtrl : DucHienMonoBehaviour
{
    [SerializeField] protected ElementSO elementSO;
    public ElementSO ElementSO { get { return elementSO; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadElementSO();
    }
    protected virtual void LoadElementSO()
    {
        if (this.elementSO != null) return;
        string path = "Element/" + transform.name;
        this.elementSO = Resources.Load<ElementSO>(path);
    }

}
