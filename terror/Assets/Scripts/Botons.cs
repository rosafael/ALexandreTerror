using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botons : MonoBehaviour
{
    [SerializeField] private string nomedolevel;
    [SerializeField] private GameObject paineljanela2;
    [SerializeField] private GameObject paineljanela1;

    public void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void abricreditos()
    {
        paineljanela1.SetActive(false);
        paineljanela2.SetActive(true);
    }
    public void fecharcreditos()
    {

        paineljanela1.SetActive(true);
        paineljanela2.SetActive(false);
    }
    public void cena()
    {
        SceneManager.LoadScene(nomedolevel);
    }
    public void CloseGame()
    {
#if UNITY_EDITOR
        // Se estiver no Editor Unity, apenas pare a execução do jogo
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Se estiver em uma compilação, feche o aplicativo
        Application.Quit();
#endif
    }


}
