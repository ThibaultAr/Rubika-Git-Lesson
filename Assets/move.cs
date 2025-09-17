using UnityEngine;

public class AutoMove : MonoBehaviour
{
    float verticalInput;
    float horizontalInput;
    [SerializeField] Rigidbody componentRigidbody;
    [SerializeField] float speed;
   
    // Vitesse en unit�s/seconde
    private void Start()
    {
        Debug.Log("jsp");
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput * Time.deltaTime, 0, verticalInput * Time.deltaTime);
        direction.Normalize();
        componentRigidbody.linearVelocity = direction * speed;
    }
}
