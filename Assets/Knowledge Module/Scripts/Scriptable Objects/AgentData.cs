using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AgentData : MonoBehaviour
{
    private List<InteractionRecord> m_interactionHistory = new List<InteractionRecord>();

    public void RecordInteraction(SmartObject objectInteracted, GameObject activator, bool outcomeSuccessful)
    {
        if(m_interactionHistory.Exists(item => item.interactable == objectInteracted))
        {
            var interactedItem = m_interactionHistory.Find(item => item.interactable == objectInteracted);
            Utility.IncrementInteractionSuccessAverage(ref interactedItem.successRate, ref interactedItem.amountInteracted, outcomeSuccessful);
        } else
        {
            m_interactionHistory.Add(new InteractionRecord(
                objectInteracted,
                objectInteracted.gameObject.transform.position,
                1,
                outcomeSuccessful ? 1f : 0f
            ));
        }
    } 
}
