using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObjectInteractionData : ScriptableObject
{
    [SerializeField]
    private string m_displayName;

    [SerializeField]
    private Interaction m_action;

    public bool Activate(GameObject activator, List<string> offer, SmartObject activatee)
    {
        return m_action.Activate(activator, activatee);
    }

}
