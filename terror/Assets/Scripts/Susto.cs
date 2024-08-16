using UnityEngine;
using UnityEngine.SceneManagement;

public class Susto : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    // Refer�ncia ao script FirstPersonController
    private FirstPersonController fpsController;

    private void Start()
    {
        // Tenta obter o componente FirstPersonController no mesmo GameObject
        fpsController = GetComponent<FirstPersonController>();

        // Se o FirstPersonController n�o estiver no mesmo GameObject, voc� pode procur�-lo em outro lugar
        if (fpsController == null)
        {
            fpsController = FindObjectOfType<FirstPersonController>();
        }

        // Verifica se o FirstPersonController foi encontrado
        if (fpsController == null)
        {
            Debug.LogError("FirstPersonController n�o encontrado!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Morreu"))
        {
            // Exemplo de acesso a uma vari�vel ou m�todo do FirstPersonController
            if (fpsController != null)
            {
                // Aqui voc� pode acessar propriedades ou m�todos do FirstPersonController
                // Exemplo: fpsController.enabled = false; (desabilita o controle do jogador)
            }

            // Habilita o cursor do mouse e o deixa livre
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Carrega a nova cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
