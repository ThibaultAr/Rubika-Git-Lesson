using UnityEngine;
// t moche
public class JusteBougeFDP : MonoBehaviour
{

    public Vector3 direction = Vector3.forward;
    public float speed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
