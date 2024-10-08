using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explanation : MonoBehaviour
{
    public static Explanation Instance;
    [SerializeField] public GameObject explanation;
    public bool GameActive = false;
    public void OnExplanation()
    {
        explanation.SetActive(true);
    }
    public void OutExplanation()
    {
        explanation.SetActive(false);
    }
    
}
