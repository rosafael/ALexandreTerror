using UnityEngine;
using UnityEngine.AI;

public class IAinimigo : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            agent.SetDestination(target.position);
        }
    }
}
