using System;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : ScriptableObject
{
    public List<Trait> requirements;
    public List<GameObject> offer;
    public Dictionary<Trait, float> activatorStateChange;
    public Dictionary<Trait, float> activateeStateChange;
    public Delegate sideEffect;

    // The implementation includes all the side effects an interaction should create
    public bool Activate(GameObject activator, SmartObject activatee)
    {
        if (!CheckRequirements())
        {
            return false;
        }

        return true;
    }

    public bool Activate(GameObject activator, SmartObject activatee, Delegate sideEffect)
    {
        if (!CheckRequirements())
        {
            return false;
        }

        return true;
    }


    public virtual bool CheckRequirements()
    {
        return true;
    }
}