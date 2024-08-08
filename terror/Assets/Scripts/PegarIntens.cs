using UnityEngine;

public class PegarIntens : MonoBehaviour
{
    public float rayDistance = 5f; // Distância do Raycast
    public KeyCode interactionKey = KeyCode.E; // Tecla de interação
    public GameObject objetoParaHabilitarChaveDeFenda; // Objeto a ser habilitado quando encontrar a ChaveDeFenda
    public GameObject objetoParaHabilitarChaveDaEscada; // Objeto a ser habilitado quando encontrar a ChaveDaEscada

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
                // Verifica se o objeto colidido tem a tag "ChaveDeFenda"
                if (hit.collider.CompareTag("ChaveDeFenda"))
                {
                    // Habilita o objeto associado e destrói o objeto com a tag "ChaveDeFenda"
                    if (objetoParaHabilitarChaveDeFenda != null)
                    {
                        objetoParaHabilitarChaveDeFenda.SetActive(true);
                    }
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto colidido tem a tag "ChaveDaEscada"
                else if (hit.collider.CompareTag("ChaveDaEscada"))
                {
                    // Habilita o objeto associado e destrói o objeto com a tag "ChaveDaEscada"
                    if (objetoParaHabilitarChaveDaEscada != null)
                    {
                        objetoParaHabilitarChaveDaEscada.SetActive(true);
                    }
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
