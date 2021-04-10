using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{

    /// <summary>Increments a moving average success rate.</summary>
    public static void IncrementInteractionSuccessAverage(ref float average, ref int numberOfPoints, bool isSuccess)
    {
        int outcome = isSuccess ? 1 : 0;
        numberOfPoints += 1;
        average = average * (numberOfPoints - 1) / numberOfPoints + outcome / numberOfPoints;
    }
}