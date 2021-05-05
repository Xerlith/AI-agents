using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Plot Director/Goal")]
public class PlotGoal : ScriptableObject
{
    public List<GOAPModule.GOAPResult> goals;

    public string goalDescription;

    public PlotActor actor;

    /// <summary>
    /// THe minimum ratio of an agent's similarity to the desired actor (Based on trait values).
    /// </summary>
    [Range(0,1)]
    public float ActorSelectionAccuracy;

}
