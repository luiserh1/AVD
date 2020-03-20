using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class SimpleGo : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform Destination;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = Destination.transform.position;
    }
}
