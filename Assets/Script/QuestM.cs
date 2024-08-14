using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestM : MonoBehaviour
{
    public static QuestM instance;

    public static int QNum;
    public static int Num;

    public void Start()
    {
        instance = this;
        Num = DollMakerMangaer.instance.GetComponent<Animator>().GetInteger("doll");
    }
    public void Quest()
    {
        int QNum = Random.Range(0, 4);
        Debug.Log("QNum = " + QNum);
        
    }
    public void Clear()
    {

        if (QNum == Num)
        {
            Debug.Log("Å¬¸®¾î");
            int QNum = Random.Range(0, 4);
            Debug.Log("QNum = " + QNum);
            Num = 0;
        }
        else if (QNum != Num)
        {
            Debug.Log("no");
            Num = 0;
        }
    }
}
