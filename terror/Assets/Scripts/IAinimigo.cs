using UnityEngine;
using UnityEngine.AI;

public class IAinimigo : MonoBehaviour
{
    public Transform player; // Referência ao Transform do jogador
    public float detectionRange = 10f; // Distância de detecção do jogador
    public float stoppingDistance = 1.5f; // Distância mínima antes de parar o inimigo
    public float updateRate = 0.2f; // Taxa de atualização da IA

    private NavMeshAgent agent; // Componente NavMeshAgent
    private float timer;

    void Start()
    {
        // Obtém o componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Atualiza a cada updateRate segundos
        timer += Time.deltaTime;
        if (timer >= updateRate)
        {
            timer = 0f;

            // Calcula a distância entre o inimigo e o jogador
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Verifica se o jogador está dentro do alcance de detecção
            if (distanceToPlayer <= detectionRange)
            {
                // Define a posição do jogador como destino para o NavMeshAgent
                agent.SetDestination(player.position);

                // Define a distância mínima para parar o inimigo
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
