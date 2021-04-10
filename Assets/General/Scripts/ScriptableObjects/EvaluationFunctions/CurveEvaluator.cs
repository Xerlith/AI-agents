using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Utility/CurveEvaluator")]
public class CurveEvaluator : EvaluatorBase
{
    public AnimationCurve curve;

    public override float Evaluate(float x) => curve.Evaluate(x);
}
