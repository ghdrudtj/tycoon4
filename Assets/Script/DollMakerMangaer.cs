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
    public GameObject M_Doll1_4;

    public static bool isClear;
    void Start()
    {
        instance = this;
        anim= GetComponent<Animator>(); 
        Num = GetComponent<Animator>().GetInteger("doll");
        QNum = QuestM.QNum;
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
        M_Doll1_4.SetActive(false);
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
        M_Doll1_4.SetActive(false);
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
        M_Doll1_4.SetActive(false);
    }
    public void head4()
    {
        anim.SetInteger("doll", 4);
        anim.SetBool("acc1", true);
        Num = 4;
        Debug.Log("Num = " + Num);
        M_Doll1_1.SetActive(false);
        M_Doll1_2.SetActive(false);
        M_Doll1_3.SetActive(false);
        M_Doll1_4.SetActive(true);
    }
    public void Doll1_1()
    {
        if(Num == 1||Num == 6 || Num == 7 || Num == 8)
        {
            anim.SetInteger("doll", 5);
            Num = 5;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll1_2()
    {
        if(Num == 1 || Num == 5 || Num == 8 || Num == 7) 
        {
            anim.SetInteger("doll", 6);
            Num = 6;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll1_3()
    {
        if (Num == 1 || Num == 5 || Num == 8 || Num == 6)
        {
            anim.SetInteger("doll", 7);
            Num = 7;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll1_4()
    {
        if (Num == 1 || Num == 5 || Num == 7 || Num == 6)
        {
            anim.SetInteger("doll", 8);
            Num = 8;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll2_1()
    {
        if (Num == 2 || Num == 10 || Num == 11 || Num == 12)
        {
            anim.SetInteger("doll", 9);
            Num = 9;
            Debug.Log("Num = " + Num);
        }
        
    }
    public void Doll2_2()
    {
        if (Num == 2|| Num == 10 || Num == 12 || Num == 9)
        {
            anim.SetInteger("doll", 10);
            Num = 10;
            Debug.Log("Num = " + Num);
        }
        
    }
    public void Doll2_3()
    {
        if (Num == 2 || Num == 9 || Num == 10 || Num == 12)
        {
            anim.SetInteger("doll", 11);
            Num = 11;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll2_4()
    {
        if (Num == 2 || Num == 9 || Num == 10 || Num == 11)
        {
            anim.SetInteger("doll", 12);
            Num = 12;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll3_1()
    {
        if (Num == 3 || Num == 14 || Num == 15 || Num == 16)
        {
            anim.SetInteger("doll", 13);
            Num = 13;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll3_2()
    {
        if (Num == 3 || Num == 13 || Num == 15 || Num == 16)
        {
            anim.SetInteger("doll", 14);
            Num = 14;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll3_3()
    {
        if (Num == 3 || Num == 13 || Num == 14 || Num == 16)
        {
            anim.SetInteger("doll", 15);
            Num = 15;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll3_4()
    {
        if (Num == 3 || Num == 13 || Num == 14 || Num == 15)
        {
            anim.SetInteger("doll", 16);
            Num = 16;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll4_1()
    {
        if (Num == 4 || Num == 18 || Num == 19 || Num == 20)
        {
            anim.SetInteger("doll", 17);
            Num = 17;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll4_2()
    {
        if (Num == 4 || Num == 17 || Num == 19 || Num == 20)
        {
            anim.SetInteger("doll", 18);
            Num = 18;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll4_3()
    {
        if (Num == 4 || Num == 17 || Num == 18 || Num == 20)
        {
            anim.SetInteger("doll", 19);
            Num = 19;
            Debug.Log("Num = " + Num);
        }
    }
    public void Doll4_4()
    {
        if (Num == 4 || Num == 17 || Num == 19 || Num == 18)
        {
            anim.SetInteger("doll", 20);
            Num = 20;
            Debug.Log("Num = " + Num);
        }
    }
    private void Update()
    {
        if (isClear)
        {
            Num = 0;
            anim.SetInteger("doll", 0);
            isClear= false;
        }
    }
}
