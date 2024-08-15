using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;  // Para o uso do TextMesh

public enum MonsterAI
{
    Break, Patrol, Chase
}

[RequireComponent(typeof(NavMeshAgent))]
public class IAinimigo : MonoBehaviour
{
    public Transform[] patrolPoint;
    public UnityEvent OnPatrolling, OnChasing, OnBreak;

    NavMeshAgent agent;

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

    [Header("Timer")]
    public float countdownTime = 20f; // 3 minutos
    public TextMesh countdownText;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        OnPatrolling.Invoke();
        StartCoroutine(StartCountdown());
    }

    private void Update()
    {
        print(monsterAI);

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

    IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            UpdateCountdownDisplay();
            yield return null;
        }

        // Quando o tempo acabar, aumentar a velocidade do NavMeshAgent
        agent.speed = 4.5f;
    }

    void UpdateCountdownDisplay()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
