
using UnityEngine;

public class DucHienMonoBehaviour : MonoBehaviour
{
    protected virtual void Start()
    {
        this.LoadComponents();
    }
    protected virtual void OnEnable()
    {

    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {

    }
    protected virtual void ResetValue()
    {

    }
}
