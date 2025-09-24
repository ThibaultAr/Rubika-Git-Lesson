using UnityEngine;
using System.Collections;

public class Perso : MonoBehaviour
{

    private Animator animator;
    private float Vitesse;
    private float Rotation = 80f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Marche();
        Tourner();
    }

    //Fonction Marche personnage
    void Marche()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 4f * Time.deltaTime);
            animator.SetFloat("Deplacement", 4);
            if (Input.GetKey(KeyCode.RightShift))
            {
                transform.Translate(Vector3.forward * 6f * Time.deltaTime);
                animator.SetFloat("Deplacement", 10);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * 3f * Time.deltaTime);
            animator.SetFloat("Deplacement", -3);
        }
        else
            animator.SetFloat("Deplacement", 0);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * 10f * Time.deltaTime);
            animator.SetBool("Saut", true);
        }
        else
            animator.SetBool("Saut", false);
    }

    //Fonction Rotation personnage
    void Tourner()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -Rotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, Rotation * Time.deltaTime);
        }
    }
}