using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image FadeImage;
    private float FadeAlpha = 1;

    private void Start()
    {
        StartCoroutine(Fade());
    }
    private IEnumerator Fade()
    {
        while (FadeAlpha >= 0)
        {
            FadeAlpha-=0.003f;

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, FadeAlpha);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
