using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    public Image image;
    public float tranistionTime;
    public float counter;

    public Color notFaded = Color.clear;
    public Color faded = Color.black;
    private void Start()
    {
        image.color = notFaded;
    }
    public void FadeInAnimation()
    {
        StartCoroutine(Transisition(true));
    }

    public void FadeOutAnimation()
    {
        StartCoroutine(Transisition(false));
    }

    IEnumerator Transisition(bool _in)
    {
        counter = 0;
        while (counter < tranistionTime)
        {
            counter += Time.unscaledDeltaTime;

            float factor = Mathf.Clamp01(counter / tranistionTime);

            image.color = Color.Lerp(faded, notFaded, factor * (_in ? 1 : -1));

            yield return null;
        }
    }
}
