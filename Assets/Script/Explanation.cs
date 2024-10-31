using UnityEngine;
using UnityEngine.UI;

public class Explanation : MonoBehaviour
{
    public static Explanation Instance;
    [SerializeField] public GameObject explanation;
    [SerializeField] public GameObject image1;
    [SerializeField] public GameObject image2;
    public void OnExplanation()
    {
        explanation.SetActive(true);
    }
    public void OutExplanation()
    {
        explanation.SetActive(false);
    }
    public void Next()
    {
        image2.SetActive(true);
        image1.SetActive(false);
    }
    public void Prev()
    {
        image1.SetActive(true);
        image2.SetActive(false);
    }
}

