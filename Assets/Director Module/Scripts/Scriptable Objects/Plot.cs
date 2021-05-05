using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plot : ScriptableObject
{
    public List<PlotGoal> goals;
    public List<PlotActor> actors
    {
        get
        {
            return goals.Select(o => o.actor).ToList();
        }
    }

    /// <summary>
    /// An informational text unused by the system.
    /// </summary>
    public string description;

}
