using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;            // vitesse de d�placement
    public float jumpForce = 5f;        // force du saut
    public Rigidbody rb;                // rigidbody du joueur
    public Transform cameraTransform;   // r�f�rence � la cam�ra

    private Vector3 moveDirection;
    private bool isGrounded = true;     // savoir si le joueur est au sol

    void Update()
    {
        // R�cup�re input clavier
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou fl�ches
        float vertical = Input.GetAxis("Vertical");     // W/S ou fl�ches

        // Direction selon la cam�ra
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // On ignore la rotation verticale de la cam�ra
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calcule la direction de d�placement
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
        // D�placement avec Rigidbody
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);

        // Tourner le joueur dans la direction du mouvement
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.15f);
        }
    }

    // V�rifie si le joueur touche le sol
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f) // contact avec le sol
        {
            isGrounded = true;
        }
    }
}