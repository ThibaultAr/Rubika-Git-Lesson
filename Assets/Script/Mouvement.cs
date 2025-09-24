using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;            // vitesse de déplacement
    public float jumpForce = 5f;        // force du saut
    public Rigidbody rb;                // rigidbody du joueur
    public Transform cameraTransform;   // référence à la caméra

    private Vector3 moveDirection;
    private bool isGrounded = true;     // savoir si le joueur est au sol

    void Update()
    {
        // Récupère input clavier
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou flèches
        float vertical = Input.GetAxis("Vertical");     // W/S ou flèches

        // Direction selon la caméra
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // On ignore la rotation verticale de la caméra
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calcule la direction de déplacement
        moveDirection = (forward * vertical + right * horizontal).normalized;

        // Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Déplacement avec Rigidbody
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);

        // Tourner le joueur dans la direction du mouvement
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.15f);
        }
    }

    // Vérifie si le joueur touche le sol
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f) // contact avec le sol
        {
            isGrounded = true;
        }
    }
}