using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EvaluatorBase : ScriptableObject
{
    public abstract float Evaluate(float x);
}
