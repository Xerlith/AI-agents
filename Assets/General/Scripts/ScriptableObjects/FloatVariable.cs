using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    [SerializeField]
    private float m_value;

    private float currentValue;

    public FloatVariable(float value) 
    {
        m_value = value;
    }
    public float Value
    {
        get { return currentValue; }
        set { currentValue = value; }
    }

    private void OnEnable()
    {
        currentValue = m_value;
    }
}
