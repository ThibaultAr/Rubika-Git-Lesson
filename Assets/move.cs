using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; // Direction du mouvement (par défaut: avant Z+)
    public float speed = 5f;                     // Vitesse en unités/seconde
    private void Start()
    {
        Debug.Log("jsp");
    }
    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
