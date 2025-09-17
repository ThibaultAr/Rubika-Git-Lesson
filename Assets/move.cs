using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;           // Vitesse de déplacement
    public float gravity = -9.81f;     // Gravité
    public float jumpHeight = 2f;      // Hauteur de saut
    public float mouseSensitivity = 100f; // Sensibilité de la souris
    public Transform cameraTransform;  // Référence à la caméra

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Cache et verrouille la souris
    }

    void Update()
    {
        // --- Déplacement Horizontal ---
        float x = Input.GetAxis("Horizontal"); // Q/D ou A/D
        float z = Input.GetAxis("Vertical");   // Z/S ou W/S
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // --- Gravité et Saut ---
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f; // Collé au sol

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // --- Rotation avec la souris ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
