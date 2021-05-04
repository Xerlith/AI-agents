using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOAPModule {
    public class GOAPNode : ScriptableObject
    {
        public List<GOAPRequirement> requirements;
        public List<GOAPResult> results;

        // Meta information
        public string nodeDescription;        
    }

}