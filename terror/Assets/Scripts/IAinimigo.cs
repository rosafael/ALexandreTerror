using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum MonsterAI
{
    Break, Patrol, Chase
}

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class IAinimigo : MonoBehaviour
{
    public Transform[] patrolPoint;
    public UnityEvent OnPatrolling, OnChasing, OnBreak;

    NavMeshAgent agent;
    Animator animator;  // Referência ao Animator

    [Header("Radius")]
    [SerializeField] float SetRadius;

    [Header("Identifier")]
    public Transform playerPos, vision;
    RaycastHit hit;

    [Header("StateMachine")]
    MonsterAI monsterAI;

    public bool CanPatrol;
    int lastPoint;
    int pointsToPatrol;

    [Header("Timer Settings")]
    public float countdownTime = 60f; // Tempo inicial de 1 minuto
    private bool speedIncreased = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();  // Inicializa o Animator
        OnPatrolling.Invoke();
    }

    private void Update()
    {
        // Decrementar o cronômetro
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
        }
        else if (!speedIncreased)
        {
            // Aumentar a velocidade do NavMeshAgent após o cronômetro expirar
            agent.speed = 4.5f;
            speedIncreased = true;
        }

        print(monsterAI);

        // Atualiza a animação com base na velocidade do agente
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);  // Ativa a animação de andar
        }
        else
        {
            animator.SetBool("isWalking", false);  // Ativa a animação de parado
        }

        if (Physics.Linecast(vision.position, playerPos.position, out hit))
        {
            if (hit.distance >= 10)
            {
                return;
            }
            if (hit.collider.CompareTag("Player"))
            {
                print(hit.collider.name);
                if (!monsterAI.Equals(MonsterAI.Chase))
                {
                    SetMonsterAI(MonsterAI.Chase);
                }
                agent.SetDestination(playerPos.position);
            }
        }

        if (monsterAI.Equals(MonsterAI.Chase))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                monsterAI = MonsterAI.Patrol;
                NextPointFixedPoint();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PatrolPoint"))
        {
            NextPointFixedPoint();
            print(pointsToPatrol);
        }
    }

    public void NextPointFixedPoint()
    {
        agent.SetDestination(patrolPoint[pointsToPatrol].position);
        pointsToPatrol++;
        if (pointsToPatrol >= patrolPoint.Length)
        {
            pointsToPatrol = 0;
        }
    }

    IEnumerator BreakTime()
    {
        yield return new WaitForSeconds(2);
        monsterAI = MonsterAI.Patrol;
        StopAllCoroutines();
    }

    public void SetMonsterAI(MonsterAI state)
    {
        monsterAI = state;
        switch (monsterAI)
        {
            case MonsterAI.Break:
                OnBreak.Invoke();
                break;
            case MonsterAI.Patrol:
                NextPointFixedPoint();
                OnPatrolling.Invoke();
                break;
            case MonsterAI.Chase:
                OnChasing.Invoke();
                break;
        }
    }
}
