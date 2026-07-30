using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Este método irá conectado a tu botón de Resume
    public void ClickReanudar()
    {
        // Busca el script principal que se quedó en la escena de fondo
        GamePauseController controladorPrincipal = FindObjectOfType<GamePauseController>();
        
        if (controladorPrincipal != null)
        {
            controladorPrincipal.ResumeGame();
        }
        else
        {
            Debug.LogWarning("No se encontró el GamePauseController en la escena principal.");
        }
    }
}