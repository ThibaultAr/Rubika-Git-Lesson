using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionVFX;


    void OnCollisionEnter(Collision collision)
    {
        Instantiate(playerExplosionVFX);
        Destroy(collision.gameObject);
    }
}
