using UnityEngine;

public class Carro : MonoBehaviour
{
    // Listas para lidar com m�ltiplos pneus em ordem
    public GameObject[] objetosParaVerificarPneus; // Objetos que precisam estar habilitados
    public GameObject[] objetosParaHabilitarPneus; // Objetos que ser�o habilitados ao interagir
    public GameObject[] objetosParaDestruirPneus; // Objetos que ser�o destru�dos ao interagir
    public float raycastDistance = 23f; // Dist�ncia do raycast

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
                // Verifica se o objeto atingido possui a tag "Carro"
                if (hit.collider.CompareTag("Carro"))
                {
                    // Itera sobre cada conjunto de pneus em ordem
                    for (int i = 0; i < objetosParaVerificarPneus.Length; i++)
                    {
                        // Verifica se o objeto de verifica��o atual est� habilitado
                        if (objetosParaVerificarPneus[i] != null && objetosParaVerificarPneus[i].activeInHierarchy)
                        {
                            // Habilita o objeto correspondente
                            if (objetosParaHabilitarPneus[i] != null)
                            {
                                objetosParaHabilitarPneus[i].SetActive(true);
                            }

                            // Destr�i o objeto correspondente
                            if (objetosParaDestruirPneus[i] != null)
                            {
                                Destroy(objetosParaDestruirPneus[i]);
                            }

                            // Sai do loop ap�s encontrar o primeiro pneu habilitado
                            break;
                        }
                    }
                }
            }
        }
    }
}
