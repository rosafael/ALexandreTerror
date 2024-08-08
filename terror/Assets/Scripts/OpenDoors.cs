using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public float rayDistance = 5f; // Dist�ncia do Raycast
    public KeyCode interactionKey = KeyCode.E; // Tecla de intera��o
    public GameObject chaveDeFenda; // Objeto necess�rio para abrir portas "DoorFenda"
    public GameObject chaveDaEscada; // Objeto necess�rio para abrir portas "DoorEscada"

    void Update()
    {
        // Verifica se a tecla de intera��o foi pressionada
        if (Input.GetKeyDown(interactionKey))
        {
            // Lan�a o Raycast a partir da posi��o da c�mera do jogador para frente
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Verifica se o Raycast colidiu com algum objeto
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // Verifica se o objeto colidido tem a tag "Door"
                if (hit.collider.CompareTag("Door"))
                {
                    // Destr�i o objeto
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto colidido tem a tag "DoorFenda" e se a chave de fenda est� ativa
                else if (hit.collider.CompareTag("DoorFenda") && chaveDeFenda != null && chaveDeFenda.activeInHierarchy)
                {
                    // Destr�i a chave de fenda
                    Destroy(chaveDeFenda);

                    // Destr�i a porta
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto colidido tem a tag "DoorEscada" e se a chave da escada est� ativa
                else if (hit.collider.CompareTag("DoorEscada") && chaveDaEscada != null && chaveDaEscada.activeInHierarchy)
                {
                    // Destr�i a chave da escada
                    Destroy(chaveDaEscada);

                    // Destr�i a porta
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
