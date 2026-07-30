using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Configuración del Efecto")]
    [SerializeField] private Vector3 escalaHover = new Vector3(1.1f, 1.1f, 1.1f); // Qué tanto crece
    [SerializeField] private float alturaLevante = 10f; // Cuántos píxeles sube
    [SerializeField] private float velocidad = 15f; // Qué tan rápido hace el efecto

    private RectTransform rectTransform;
    private Vector3 escalaOriginal;
    private Vector3 posicionOriginal;
    
    private Vector3 escalaObjetivo;
    private Vector3 posicionObjetiva;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
        // Guardamos los valores originales al iniciar
        escalaOriginal = rectTransform.localScale;
        posicionOriginal = rectTransform.anchoredPosition;

        // Establecemos los objetivos iniciales
        escalaObjetivo = escalaOriginal;
        posicionObjetiva = posicionOriginal;
    }

    void Update()
    {
        // Interpolamos suavemente hacia el objetivo. 
        // Usamos unscaledDeltaTime para que funcione en el menú de pausa.
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, escalaObjetivo, Time.unscaledDeltaTime * velocidad);
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, posicionObjetiva, Time.unscaledDeltaTime * velocidad);
    }

    // Se activa cuando el mouse ENTRA en el área del botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        escalaObjetivo = escalaHover;
        posicionObjetiva = posicionOriginal + new Vector3(0, alturaLevante, 0);
    }

    // Se activa cuando el mouse SALE del área del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        escalaObjetivo = escalaOriginal;
        posicionObjetiva = posicionOriginal;
    }
}