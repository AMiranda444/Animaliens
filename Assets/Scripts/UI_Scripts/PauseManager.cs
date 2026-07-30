using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Referencias de UI")]
    [SerializeField] private GameObject pauseMenuUI; // Asigna aquí el panel de pausa

    private bool isPaused = false;

    void Update()
    {
        // Al presionar Escape (o P), conmuta la pausa
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

    // Método para reanudar la partida (Conéctalo al botón Resume)
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Oculta la UI
        Time.timeScale = 1f;          // Reactiva el tiempo del juego
        isPaused = false;
    }

    // Método para pausar la partida
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);  // Muestra la UI
        Time.timeScale = 0f;          // Congela el movimiento/tiempo del juego
        isPaused = true;
    }
}