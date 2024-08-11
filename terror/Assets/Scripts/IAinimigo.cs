using UnityEngine;

public class IAinimigo : MonoBehaviour
{
    public Transform player; // Refer�ncia ao jogador
    public float speed = 5f; // Velocidade de movimento do monstro
    private bool isChasing = false; // Flag para saber se est� perseguindo

    private void Update()
    {
        if (isChasing)
        {
            // Calcular a dire��o para o jogador
            Vector3 direction = (player.position - transform.position).normalized;
            // Mover o monstro em dire��o ao jogador
            transform.position += direction * speed * Time.deltaTime;
            // Opcional: Rotacionar o monstro para olhar para o jogador
            transform.LookAt(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar se o objeto que entrou no trigger � o jogador
        if (other.CompareTag("Player"))
        {
            isChasing = true;
        }
    }
}
