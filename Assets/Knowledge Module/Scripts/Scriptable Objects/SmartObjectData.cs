using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObjectData : RuntimeSet<SmartObject>
{
    [SerializeField]
    public float BroadcastStrength { get; }

    [SerializeField]
    private List<Trait> m_traitList;

    public List<Trait> TraitList => m_traitList;

    [SerializeField]
    private List<SmartObjectInteractionData> m_interactions;

    public List<SmartObjectInteractionData> Interactions => this.m_interactions;

}
