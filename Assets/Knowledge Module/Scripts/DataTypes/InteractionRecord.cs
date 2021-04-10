using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InteractionRecord
{
    public SmartObject interactable;
    public Vector3 lastSeen;
    public int amountInteracted;
    public float successRate;

    public InteractionRecord(SmartObject interactable, Vector3 lastSeen, int amountInteracted, float successRate)
    {
        this.interactable = interactable;
        this.lastSeen = lastSeen;
        this.amountInteracted = amountInteracted;
        this.successRate = successRate;
    }
}

