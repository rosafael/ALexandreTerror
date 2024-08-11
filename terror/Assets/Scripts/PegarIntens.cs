using UnityEngine;

public class PegarIntens : MonoBehaviour
{
    public float raycastDistance = 2f; // Distância do raycast
    public GameObject objetoParaHabilitarChaveCasa; // Objeto para habilitar quando a chave for coletada
    public GameObject objetoParaHabilitarPeDeCabra; // Objeto para habilitar quando o pé de cabra for coletado

    void Update()
    {
        // Verifica se a tecla E foi pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Lança o raycast a partir da posição da câmera
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // Verifica se o objeto atingido possui a tag "ChaveCasa"
                if (hit.collider.CompareTag("ChaveCasa"))
                {
                    // Habilita o objeto desejado para a chave
                    if (objetoParaHabilitarChaveCasa != null)
                    {
                        objetoParaHabilitarChaveCasa.SetActive(true);
                    }

                    // Destrói o objeto com a tag "ChaveCasa"
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto atingido possui a tag "PeDeCabra"
                else if (hit.collider.CompareTag("PeDeCabra"))
                {
                    // Habilita o objeto desejado para o pé de cabra
                    if (objetoParaHabilitarPeDeCabra != null)
                    {
                        objetoParaHabilitarPeDeCabra.SetActive(true);
                    }

                    // Destrói o objeto com a tag "PeDeCabra"
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
