using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOAPModule
{
    public class GOAPRequirement : ScriptableObject
    {
        public Dictionary<Trait, float> traitValues;


        public bool Evaluate(GameObject actor)
        {
            return true;
        }
    }
}