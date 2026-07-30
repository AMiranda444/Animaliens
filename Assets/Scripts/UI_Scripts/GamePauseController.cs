using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseController : MonoBehaviour
{
    [Header("Configuración")]
    // Escribe aquí EXACTAMENTE el nombre de tu escena de pausa
    public string nombreEscenaPausa = "MenuPausa"; 
    
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Congela el tiempo
        // Carga la escena de pausa POR ENCIMA de la actual
        SceneManager.LoadScene(nombreEscenaPausa, LoadSceneMode.Additive);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Descongela el tiempo
        // Descarga (cierra) únicamente la escena de pausa
        SceneManager.UnloadSceneAsync(nombreEscenaPausa);
    }
}