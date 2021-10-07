using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SOTags;

//TODO: Make static after confirming the return values in the editor
public class ActorSelector : MonoBehaviour
{
    public List<GameObject> agentList;

    public Plot plot;

    public class ActorAssignment
    {
        public GameObject agent;
        public PlotGoal role;
    }

    [SerializeField]
    private List<ActorAssignment> plotAssignments;

    public void assignAgentsToRoles()
    {
        plot.goals.ForEach(role =>
        {
            List<KeyValuePair<GameObject, float>> eligibilityList = new List<KeyValuePair<GameObject, float>>();
            agentList.ForEach(agent => {
                float eligibility = measureActorEligibility(agent, role);
                if (eligibility > 0f)
                {
                    eligibilityList.Add(new KeyValuePair<GameObject, float>(agent, eligibility));
                }
            });
        });
   

        // Get the goals list
        // for every goal, go through all the agents
        // check agent eligibility by looking if the actor has all the traits required
        // Discard those who don't. Then check for eligibility among those who do, by checking the trait values multiplied by the accuracy coefficient
        // Best to insert those in a sorted way.
        // Get the topmost one and create an ActorAssignment.
        // Note: Any Plot that's eligible to run this script has first compared a general trait list with the 
    }

    private static float measureActorEligibility(GameObject agent, PlotGoal role)
    {
        // Fail the agent if they don't have the traits in the first place
        if (!doesAgentHaveRequisiteTraits(agent, role.actor.traits)) return 0f;
        
        foreach (var trait in role.actor.traits)
        {
            
        }
        return 1.0f;

    }

    private static bool doesAgentHaveRequisiteTraits(GameObject agent, List<Trait> traits)
    {
        return agent.HasTags(traits.Select(x => x.tag).ToArray(), true);
    }
}
