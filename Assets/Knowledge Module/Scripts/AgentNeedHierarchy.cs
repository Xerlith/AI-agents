using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AgentNeedHierarchy : MonoBehaviour
{
    [System.Serializable]
    public struct UtilityAIEntry
    {
        public AILayer layer;
        public EvaluatorBase evaluator;
        public FloatVariable utilityWeight;
        public float satietyLevel;
    }

    [SerializeField]
    private List<UtilityAIEntry> layers = new List<UtilityAIEntry>();

    public Dictionary<Trait, float> traits = new Dictionary<Trait, float>();
    
    public AILayer SelectIntention()
    {
        var decisionWeights = new Dictionary<AILayer, float>();
        foreach (var item in layers)
        {
            decisionWeights.Add(item.layer, item.evaluator.Evaluate(1 - item.satietyLevel) * item.utilityWeight.Value);
        }

        return decisionWeights.OrderByDescending(e => e.Value)
            .First()
            .Key;
    }


}
