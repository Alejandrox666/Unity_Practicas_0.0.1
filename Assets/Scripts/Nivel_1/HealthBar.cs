using UnityEngine;
using UnityEngine.UI; // Necesario para usar el componente Slider

public class HealthBar : MonoBehaviour
{
    // Referencia al componente Slider (se asigna automáticamente ya que está en el mismo objeto)
    public Slider slider;

    // Configura la vida máxima (para el inicio)
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Configura la vida actual (para la actualización)
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}