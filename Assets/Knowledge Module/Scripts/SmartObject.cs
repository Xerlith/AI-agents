using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObject : MonoBehaviour
{

    [SerializeField]
    private SmartObjectData m_data;

    // Start is called before the first frame update
    void Start()
    {
        RegisterBroadcast();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RegisterBroadcast()
    {
        m_data.Add(this);
    }
}
