using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necess�rio para gerenciar cenas

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
        // Verifica se todos os objetos na lista est�o destru�dos
        foreach (GameObject objeto in objetosParaVerificar)
        {
            if (objeto != null)
            {
                // Se qualquer objeto n�o estiver destru�do, sai do m�todo
                return;
            }
        }

        // Se todos os objetos est�o destru�dos, troca de cena
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
