using UnityEngine;

public class ItensCarro : MonoBehaviour
{
    public float raycastDistance = 2f; // Dist�ncia do raycast
    public GameObject objetoParaHabilitarPneu;  // Objeto para habilitar quando o Pneu for coletado
    public GameObject objetoParaHabilitarPneu1; // Objeto para habilitar quando o Pneu1 for coletado
    public GameObject objetoParaHabilitarPneu2; // Objeto para habilitar quando o Pneu2 for coletado
    public GameObject objetoParaHabilitarPneu3; // Objeto para habilitar quando o Pneu3 for coletado

    void Update()
    {
        // Verifica se a tecla E foi pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Lan�a o raycast a partir da posi��o da c�mera
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // Verifica se o objeto atingido possui a tag "Pneu"
                if (hit.collider.CompareTag("Pneu"))
                {
                    // Habilita o objeto desejado para Pneu
                    if (objetoParaHabilitarPneu != null)
                    {
                        objetoParaHabilitarPneu.SetActive(true);
                    }

                    // Destr�i o objeto com a tag "Pneu"
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto atingido possui a tag "Pneu1"
                else if (hit.collider.CompareTag("Pneu1"))
                {
                    // Habilita o objeto desejado para Pneu1
                    if (objetoParaHabilitarPneu1 != null)
                    {
                        objetoParaHabilitarPneu1.SetActive(true);
                    }

                    // Destr�i o objeto com a tag "Pneu1"
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto atingido possui a tag "Pneu2"
                else if (hit.collider.CompareTag("Pneu2"))
                {
                    // Habilita o objeto desejado para Pneu2
                    if (objetoParaHabilitarPneu2 != null)
                    {
                        objetoParaHabilitarPneu2.SetActive(true);
                    }

                    // Destr�i o objeto com a tag "Pneu2"
                    Destroy(hit.collider.gameObject);
                }
                // Verifica se o objeto atingido possui a tag "Pneu3"
                else if (hit.collider.CompareTag("Pneu3"))
                {
                    // Habilita o objeto desejado para Pneu3
                    if (objetoParaHabilitarPneu3 != null)
                    {
                        objetoParaHabilitarPneu3.SetActive(true);
                    }

                    // Destr�i o objeto com a tag "Pneu3"
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
