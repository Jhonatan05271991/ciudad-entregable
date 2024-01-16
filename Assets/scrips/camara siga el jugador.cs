using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo;           // Referencia al transform del jugador
    public Vector3 offset = new Vector3(155f, 72.8f, -8.8f);  // Offset de la cámara (ajústalo según tus necesidades)
    public float suavidad = 5f;          // Suavidad del seguimiento

    void LateUpdate()
    {
        if (objetivo == null)
        {
            Debug.LogWarning("No se ha asignado un objetivo para la cámara.");
            return;
        }

        // Calcular la posición deseada de la cámara
        Vector3 posicionDeseada = objetivo.position + offset;

        // Interpolar suavemente entre la posición actual y la deseada
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavidad * Time.deltaTime);

        // La cámara siempre mira al jugador
        transform.LookAt(objetivo.position);
    }
}
