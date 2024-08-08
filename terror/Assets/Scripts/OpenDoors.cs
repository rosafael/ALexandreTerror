using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public float rayDistance = 5f; // Distância do Raycast
    public KeyCode interactionKey = KeyCode.E; // Tecla de interação
    public GameObject chaveDeFenda; // Objeto necessário para abrir portas "DoorFenda"
    public GameObject chaveDaEscada; // Objeto necessário para abrir portas "DoorEscada"

    void Update()
    {
        // Verifica se a tecla de interação foi pressionada
        if (Input.GetKeyDown(interactionKey))
        {
            // Lança o Raycast a partir da posição da câmera do jogador para frente
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Verifica se o Raycast colidiu com algum objeto
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // Verifica se o objeto colidido tem a tag "Door"
                if (hit.collider.CompareTag("Door"))
                {
                    // Destrói o objeto
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto colidido tem a tag "DoorFenda" e se a chave de fenda está ativa
                else if (hit.collider.CompareTag("DoorFenda") && chaveDeFenda != null && chaveDeFenda.activeInHierarchy)
                {
                    // Destrói a chave de fenda
                    Destroy(chaveDeFenda);

                    // Destrói a porta
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto colidido tem a tag "DoorEscada" e se a chave da escada está ativa
                else if (hit.collider.CompareTag("DoorEscada") && chaveDaEscada != null && chaveDaEscada.activeInHierarchy)
                {
                    // Destrói a chave da escada
                    Destroy(chaveDaEscada);

                    // Destrói a porta
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
