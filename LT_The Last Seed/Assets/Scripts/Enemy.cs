using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public float SatisfactionRadius = 0.5f;
    public string TargetTag;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (agent.remainingDistance < SatisfactionRadius)
            GotoNextPoint();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(TargetTag))
            agent.destination = other.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TargetTag))
            GotoNextPoint();
    }
}