using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldspaceUtils
{
    public static Transform GetClosestTransform(Transform transform, Transform[] transforms)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach(Transform potentialTarget in transforms)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}
