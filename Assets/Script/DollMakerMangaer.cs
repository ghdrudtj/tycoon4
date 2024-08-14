using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DollMakerMangaer : MonoBehaviour
{
    public static DollMakerMangaer instance;
    public Animator anim;
    public static int Num;
    public static int QNum;

    public GameObject M_Doll1_1;
    public GameObject M_Doll1_2;
    public GameObject M_Doll1_3;

    void Start()
    {
        instance = this;
        anim= GetComponent<Animator>(); 
        Num = GetComponent<Animator>().GetInteger("doll");
    }
    public void head3()
    {
        anim.SetInteger("doll", 3);
        anim.SetBool("acc1",true);
        Num = 3;
        Debug.Log("Num = " + Num);
        M_Doll1_3.SetActive(true);
        M_Doll1_2.SetActive(false);
        M_Doll1_1.SetActive(false);
    }
    public void head2()
    {
        anim.SetInteger("doll", 2);
        anim.SetBool("acc1", true);
        Num = 2;
        Debug.Log("Num = " + Num);
        M_Doll1_2.SetActive(true);
        M_Doll1_3.SetActive(false);
        M_Doll1_1.SetActive(false);
    }
    public void head1()
    {
        anim.SetInteger("doll", 1);
        anim.SetBool("acc1", true);
        Num = 1;
        Debug.Log("Num = " + Num);
        M_Doll1_1.SetActive(true);
        M_Doll1_2.SetActive(false);
        M_Doll1_3.SetActive(false);
    }

    public void Doll1_2()
    {

        if(Num == 1)
        {
            anim.SetInteger("doll", 4);
            Num = 4;
            Debug.Log("Num = " + Num);
        }
        if (Num == 5)
        {
            anim.SetInteger("doll", 4);
            Num = 4;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll1_3()
    {
        if(Num == 1) 
        {
            anim.SetInteger("doll", 5);
            Num = 5;
            Debug.Log("Num = " + Num);
        }
        if (Num == 4)
        {
            anim.SetInteger("doll", 5);
            Num = 5;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll2_1()
    {
        if (Num == 2)
        {
            anim.SetInteger("doll", 6);
            Num = 6;
            Debug.Log("Num = " + Num);
        }
        if (Num == 7)
        {
            anim.SetInteger("doll", 6);
            Num = 6;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll2_3()
    {
        if (Num == 2)
        {
            anim.SetInteger("doll", 7);
            Num = 7;
            Debug.Log("Num = " + Num);
        }
        if (Num == 6)
        {
            anim.SetInteger("doll", 7);
            Num = 7;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll3_1()
    {
        if (Num == 3)
        {
            anim.SetInteger("doll", 8);
            Num = 8;
            Debug.Log("Num = " + Num);
        }
        if (Num == 9)
        {
            anim.SetInteger("doll", 8);
            Num = 8;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll3_2()
    {
        if (Num == 3)
        {
            anim.SetInteger("doll", 9);
            Num = 9;
            Debug.Log("Num = " + Num);
        }
        if (Num == 8)
        {
            anim.SetInteger("doll", 9);
            Num = 9;
            Debug.Log("Num = " + Num);
        }

    }
}
