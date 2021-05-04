using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trait : ScriptableObject
{

    public SOTags.Tag tag;
    public float value;

    [SerializeField]
    private List<AILayer> m_affectedLayers;
}
