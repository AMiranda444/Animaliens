using UnityEngine;
using UnityEngine.AI;

public class NPCPatrolNavMesh : MonoBehaviour
{
    public Transform[] waypoints;

    private NavMeshAgent agent;
    private int currentWaypoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        if (!agent.pathPending &&
            agent.remainingDistance < 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}