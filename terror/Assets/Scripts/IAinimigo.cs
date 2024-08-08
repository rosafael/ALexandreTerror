using UnityEngine;
using UnityEngine.AI;

public class IAinimigo : MonoBehaviour
{
    public Transform player; // Refer�ncia ao Transform do jogador
    public float detectionRange = 10f; // Dist�ncia de detec��o do jogador
    public float stoppingDistance = 1.5f; // Dist�ncia m�nima antes de parar o inimigo
    public float updateRate = 0.2f; // Taxa de atualiza��o da IA

    private NavMeshAgent agent; // Componente NavMeshAgent
    private float timer;

    void Start()
    {
        // Obt�m o componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Atualiza a cada updateRate segundos
        timer += Time.deltaTime;
        if (timer >= updateRate)
        {
            timer = 0f;

            // Calcula a dist�ncia entre o inimigo e o jogador
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Verifica se o jogador est� dentro do alcance de detec��o
            if (distanceToPlayer <= detectionRange)
            {
                // Define a posi��o do jogador como destino para o NavMeshAgent
                agent.SetDestination(player.position);

                // Define a dist�ncia m�nima para parar o inimigo
                agent.stoppingDistance = stoppingDistance;
            }
            else
            {
                // Para o movimento do inimigo se o jogador estiver fora do alcance
                agent.ResetPath();
            }
        }
    }
}
