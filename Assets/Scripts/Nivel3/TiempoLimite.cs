using UnityEngine;
using UnityEngine.UI;
using TMPro;   // ← IMPORTANTE para TextMeshPro

public class TiempoLimite : MonoBehaviour
{
    [Header("Tiempo total en segundos")]
    public float tiempoTotal = 30f;

    [Header("UI")]
    public Image circuloTiempo;        // ← Círculo radial (Image fill)
    public TextMeshProUGUI textoTiempo; // ← Ahora es TextMeshProUGUI
    public GameObject panelTiempoTerminado; // ← Panel que se muestra al perder

    private float tiempoRestante;
    private bool tiempoActivo = true;

    void Start()
    {
        tiempoRestante = tiempoTotal;

        if (panelTiempoTerminado != null)
            panelTiempoTerminado.SetActive(false);
    }

    void Update()
    {
        if (!tiempoActivo) return;

        tiempoRestante -= Time.deltaTime;

        // Evitar negativos
        if (tiempoRestante < 0)
        {
            tiempoRestante = 0;
            TiempoAgotado();
        }

        // Actualizar UI del círculo
        if (circuloTiempo != null)
        {
            circuloTiempo.fillAmount = tiempoRestante / tiempoTotal;
        }

        // Actualizar texto numérico
        if (textoTiempo != null)
        {
            textoTiempo.text = Mathf.Ceil(tiempoRestante).ToString();
        }
    }

    void TiempoAgotado()
    {
        tiempoActivo = false;
        Debug.Log("⏳ Tiempo finalizado");

        // Mostrar panel final
        if (panelTiempoTerminado != null)
            panelTiempoTerminado.SetActive(true);

        Time.timeScale = 0f;
    }

    // LLAMA A ESTA FUNCIÓN CUANDO EL JUGADOR GANA
    public void DetenerTiempoPorVictoria()
    {
        tiempoActivo = false;
        Debug.Log("🏆 Tiempo detenido por victoria");

        // Evitar que el círculo siga bajando
        if (circuloTiempo != null)
            circuloTiempo.fillAmount = tiempoRestante / tiempoTotal;
    }
}
