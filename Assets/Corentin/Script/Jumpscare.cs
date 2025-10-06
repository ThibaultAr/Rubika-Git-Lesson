using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Jumpscare : MonoBehaviour
{
    
    public GameObject picture;
    public bool animInPlay;
    public Animator anim;

    public void Start()
    {
        picture.SetActive(false);
        animInPlay = false;
    }

    private void Update()
    {
        if (Random.Range(0,1000) <= 1 && !animInPlay)
        {
            StartCoroutine(JumpscareAnimCorout());
        }
    }

    public IEnumerator JumpscareAnimCorout()
    {
        animInPlay = true;
        picture.SetActive(true);
        anim.SetTrigger("Jumpscare");
        yield return new WaitForSeconds(1f);
        picture.SetActive(false);
        yield return new WaitForSeconds(20f);
        animInPlay = false;
    }
}
