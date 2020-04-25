using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class FadeLoader : MonoBehaviour
{

    [SerializeField] Image fadeImg;

    public UnityEvent OnFadeStart;
    public UnityEvent onFadeInComplete;
    public UnityEvent onFadeOutComplete;

    void Awake()
    {
        Color t = fadeImg.color;
        t.a = 1;
        fadeImg.color = t;
    }

    public void Wait(float dur)
    {
        StartCoroutine(IeWait(dur));
    }

    public void FadeIn(float dur)
    {
        fadeImg.gameObject.SetActive(true);
        StartCoroutine(FadeImage(false, dur));
    }

    public void FadeOut(float dur)
    {
        fadeImg.gameObject.SetActive(true);
        StartCoroutine(FadeImage(true, dur));
    }

    public IEnumerator IeWait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    IEnumerator FadeImage(bool fadeOut, float duration)
    {
        OnFadeStart.Invoke();
        if (fadeOut)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime / duration)
            {
                fadeImg.color = new Color(0, 0, 0, i);
                yield return null;
            }
            onFadeOutComplete.Invoke();
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime / duration)
            {
                fadeImg.color = new Color(0, 0, 0, i);
                yield return null;
            }
            onFadeInComplete.Invoke();
        }
    }
}
