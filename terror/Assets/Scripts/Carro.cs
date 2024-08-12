using UnityEngine;

public class Carro : MonoBehaviour
{
    // Listas para lidar com múltiplos pneus em ordem
    public GameObject[] objetosParaVerificar; // Objetos que precisam estar habilitados
    public GameObject[] objetosParaHabilitars; // Objetos que serão habilitados ao interagir
    public GameObject[] objetosParaDestruir; // Objetos que serão destruídos ao interagir
    public float raycastDistance = 23f; // Distância do raycast

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
                // Verifica se o objeto atingido possui a tag "Carro"
                if (hit.collider.CompareTag("Carro"))
                {
                    // Itera sobre cada conjunto de pneus em ordem
                    for (int i = 0; i < objetosParaVerificar.Length; i++)
                    {
                        // Verifica se o objeto de verificação atual está habilitado
                        if (objetosParaVerificar[i] != null && objetosParaVerificar[i].activeInHierarchy)
                        {
                            // Habilita o objeto correspondente
                            if (objetosParaHabilitars[i] != null)
                            {
                                objetosParaHabilitars[i].SetActive(true);
                            }

                            // Destrói o objeto correspondente
                            if (objetosParaDestruir[i] != null)
                            {
                                Destroy(objetosParaDestruir[i]);
                            }

                            // Sai do loop após encontrar o primeiro pneu habilitado
                            break;
                        }
                    }
                }
            }
        }
    }
}
