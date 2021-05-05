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
    public List<SOTags.Tag> traits;
    public List<float> traitValues;

    /// <summary>
    /// An informational text unused by the system.
    /// </summary>
    public string description;

    public Dictionary<SOTags.Tag, float> traitsWithValues {
        get
        {
            return traits.Zip(traitValues, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
        }
    }
}
