using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Plot Director/Actor")]

/**
 * <summary>
 * This entry describes a desired actor (Chosen from among active AI agents) to be used in a plot.
 * </summary>
 */
public class PlotActor : ScriptableObject
{
    public List<Trait> traits;

    /// <summary>
    /// An informational text unused by the system.
    /// </summary>
    public string description;
}
