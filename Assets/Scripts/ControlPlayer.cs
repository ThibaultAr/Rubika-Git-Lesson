using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        direction.Normalize();
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }
}
  