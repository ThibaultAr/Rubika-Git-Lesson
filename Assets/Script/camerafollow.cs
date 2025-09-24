using UnityEngine;

public class Follow_player : MonoBehaviour
{
    public Transform player;        // le perso � suivre
    public float distance = 5.0f;   // distance de la cam�ra
    public float height = 2.0f;     // hauteur de la cam�ra
    public float sensitivity = 2.0f; // vitesse de rotation avec la souris

    private float rotationX = 0f;   // rotation horizontale
    private float rotationY = 0f;   // rotation verticale

    void LateUpdate()
    {
        if (player == null) return;

        // R�cup�re mouvement souris
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp la rotation verticale (emp�che de retourner la cam�ra)
        rotationY = Mathf.Clamp(rotationY, -20f, 60f);

        // Calcul de la position de la cam�ra
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        Vector3 position = player.position - rotation * Vector3.forward * distance + Vector3.up * height;

        // Applique la position et la rotation
        transform.position = position;
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}