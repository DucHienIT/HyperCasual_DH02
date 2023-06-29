using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Round", menuName = "ScriptableObject/Round")]
public class RoundSO : ScriptableObject
{
    public int RoundIndex = 1;
    public List<string> elementInRound = new List<string>();
}