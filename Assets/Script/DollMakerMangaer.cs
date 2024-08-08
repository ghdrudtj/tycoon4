using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DollMakerMangaer : MonoBehaviour
{
    Animator anim;
    public int Num;
    void Start()
    {
        anim= GetComponent<Animator>(); 
    }

    void Update()
    {
        anim.SetInteger("doll", Num);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (gameObject.name=="head1")
        {
            anim.SetInteger("doll", 1);
            anim.SetBool("Head",true);
        }
        if (gameObject.name == "head2")
        {
            anim.SetInteger("doll", 2);
            anim.SetBool("Head", true);
        }
        if (gameObject.name == "head3")
        {
            anim.SetInteger("doll", 3);
            anim.SetBool("Head", true);
        }
    }
   
}
