using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Plot Director/Goal")]
public class PlotGoal : ScriptableObject
{
    public List<GOAPModule.GOAPResult> goals;

    public string goalDescription;

}
