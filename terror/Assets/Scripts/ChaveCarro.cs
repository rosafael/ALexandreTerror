using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para gerenciar cenas

public class ChaveCarro : MonoBehaviour
{
    public float raycastDistance = 2f;
    public List<GameObject> objetosParaVerificar; // Lista de objetos a verificar
    public string nomeDaCenaParaCarregar; // Nome da cena para carregar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Carro"))
                {
                    VerificarObjetosDestruidos();
                }
            }
        }
    }

    void VerificarObjetosDestruidos()
    {
        // Verifica se todos os objetos na lista estão destruídos
        foreach (GameObject objeto in objetosParaVerificar)
        {
            if (objeto != null)
            {
                // Se qualquer objeto não estiver destruído, sai do método
                return;
            }
        }

        // Se todos os objetos estão destruídos, troca de cena
        CarregarCena();
    }

    void CarregarCena()
    {
        if (!string.IsNullOrEmpty(nomeDaCenaParaCarregar))
        {
            SceneManager.LoadScene(nomeDaCenaParaCarregar);
        }
    }
}
