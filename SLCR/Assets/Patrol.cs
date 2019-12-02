using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// Class responsible for AI patrol directly from spawn points and follow Player.
public class Patrol : MonoBehaviour
{

    public GameObject[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public int lookRadius = 5;



    /**
      *@pre agent is initialized
      *@post sets agent as a NavMeshAgent component
      *@param None.
      *@return None.
      */
    void Awake()
    {
        // = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
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
        agent.destination = points[destPoint].transform.position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }


    /**
      *@pre Agents must be spawned in.
      *@post Draws a red sphere around the AI agents on the Scene to make it easier to see how close a player can get to an AI for testing purposes
      *@param None.
      *@return None.
      */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}