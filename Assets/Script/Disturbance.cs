using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Disturbance : MonoBehaviour
{
    public static Disturbance disturbance;
    public GameObject thiefObj;
    int thiefNum;
    public int thiefMaxNum=10;
    private float ThiefcurrentTimer;
    private float ThiefmaxTimer = 10;

    void Start()
    {
        StartCoroutine(ThiefSpawn());
    }

    IEnumerator ThiefSpawn()
    {
        thieffspawn();
        //yield return new WaitForSecondsRealtime(Random.Range(20,30));
        thiefObj.SetActive(true);
        ThiefcurrentTimer = 0;

        while(ThiefcurrentTimer <= ThiefmaxTimer)
        {
            ThiefcurrentTimer += Time.deltaTime;
            Debug.Log("ThiefcurrentTimer = " + ThiefcurrentTimer);
            while (thiefMaxNum <= thiefNum)
            {
                yield return null;
                Debug.Log("성공 ");
            }
        }
        Debug.Log("실패");
        thiefObj.SetActive(false);
        thiefNum = 0;
        Coin.instance.coin -= Coin.instance.coin / 10;
        yield return new WaitForSecondsRealtime(10f);
    }
    public void thiefClick()
    {
        thiefNum++;
        Debug.Log("click = " + thiefNum);
        if (thiefNum >= thiefMaxNum)
        {
            thiefNum = 0;
            Debug.Log("성공 ");
            thiefObj.SetActive(false);
        }
    }
    void thieffspawn()
    {
        thiefObj.SetActive(true);
    }
    private void Update()
    {

    }
}
