using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del jugador
    public float velocidadRotacion = 100f; // Velocidad de rotación del jugador

    void Update()
    {
        // Obtener las entradas de teclado o joystick
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        // Calcular la dirección del movimiento
        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        // Calcular el vector de movimiento
        Vector3 movimiento = direccionMovimiento * velocidad * Time.deltaTime;

        // Mover el jugador utilizando el Rigidbody
        transform.Translate(movimiento);

        // Rotar el jugador si hay alguna entrada de movimiento horizontal
        if (movimientoHorizontal != 0f)
        {
            RotarJugador(movimientoHorizontal);
        }
    }

    void RotarJugador(float direccionHorizontal)
    {
        Vector3 direccionRotacion = new Vector3(0f, direccionHorizontal, 0f);
        Quaternion nuevaRotacion = Quaternion.Euler(direccionRotacion * velocidadRotacion * Time.deltaTime);
        transform.rotation *= nuevaRotacion;
    }
}
