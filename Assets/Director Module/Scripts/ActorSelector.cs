using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSelector : MonoBehaviour
{
    public List<GameObject> actorList;

    public Plot plot;

    public class ActorAssignment
    {
        public GameObject agent;
        public PlotActor role;
    }

    [SerializeField]
    private List<ActorAssignment> plotAssignments;

    private List<PlotActor> plotRoles
    {
        get
        {
            return this.plot.actors;
        }
    }

    public void assignAgentsToRoles()
    {
        
    }

    private float measureAssignmentAccuracy()
    {
        return 0.0f;
    }
}
