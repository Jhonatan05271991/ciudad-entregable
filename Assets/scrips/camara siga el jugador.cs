using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo;           // Referencia al transform del jugador
    public Vector3 offset = new Vector3(155f, 72.8f, -8.8f);  // Offset de la c�mara (aj�stalo seg�n tus necesidades)
    public float suavidad = 5f;          // Suavidad del seguimiento

    void LateUpdate()
    {
        if (objetivo == null)
        {
            Debug.LogWarning("No se ha asignado un objetivo para la c�mara.");
            return;
        }

        // Calcular la posici�n deseada de la c�mara
        Vector3 posicionDeseada = objetivo.position + offset;

        // Interpolar suavemente entre la posici�n actual y la deseada
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavidad * Time.deltaTime);

        // La c�mara siempre mira al jugador
        transform.LookAt(objetivo.position);
    }
}
