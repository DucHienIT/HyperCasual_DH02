using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "ScriptableObject/Element")]
public class ElementSO : ScriptableObject
{
    public string elementName = "element";
    public ElementSO element_1;
    public ElementSO element_2;
}