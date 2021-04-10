using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEvent : MonoBehaviour
{

    public float broadcastStrength;

    public List<Interaction> Interactions;

    // Start is called before the first frame update
    void Start()
    {
        Register();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Register()
    {
        // Register to local event manager
    }

    void Unregister()
    {
        // Deregister from local event manager
        Destroy(gameObject);
    }
}
