using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : ScriptableObject
{
    public List<GameObject> treeTypes;
    public float minHeight;
    public float maxHeight;
    public float verticalAdjust;
}
