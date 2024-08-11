using UnityEngine;

public class IAinimigo : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float speed = 5f; // Velocidade de movimento do monstro
    private bool isChasing = false; // Flag para saber se está perseguindo

    private void Update()
    {
        if (isChasing)
        {
            // Calcular a direção para o jogador
            Vector3 direction = (player.position - transform.position).normalized;
            // Mover o monstro em direção ao jogador
            transform.position += direction * speed * Time.deltaTime;
            // Opcional: Rotacionar o monstro para olhar para o jogador
            transform.LookAt(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar se o objeto que entrou no trigger é o jogador
        if (other.CompareTag("Player"))
        {
            isChasing = true;
        }
    }
}
