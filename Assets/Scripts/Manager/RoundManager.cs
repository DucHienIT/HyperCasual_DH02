using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : DucHienMonoBehaviour
{
    private static RoundManager instance;
    public static RoundManager Instance => instance;

    [SerializeField] protected int currentRound = 1;
    public int CurrentRound => currentRound;

    [SerializeField] protected List<RoundSO> roundList;
    public List<RoundSO> RoundList => roundList;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRoundListSO();
    }
    protected override void Start()
    {
        base.Start();
        this.StartRound();
    }

    protected virtual void LoadRoundListSO()
    {
        this.roundList = new List<RoundSO>();
        RoundSO[] roundSOs = Resources.LoadAll<RoundSO>("Rounds");
        foreach (RoundSO roundSO in roundSOs)
        {
            this.roundList.Add(roundSO);
        }
    }
    public virtual void StartRound()
    {
        if (this.currentRound > this.roundList.Count) return;
        RoundSO roundSO = this.roundList[this.currentRound - 1];
        ElementSpawner.Instance.SetElementsInRound(roundSO.elementInRound);
    }
    public virtual void NextRound()
    {
        this.currentRound++;
        this.StartRound();
    }

}
