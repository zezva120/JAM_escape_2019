using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class FadeLoader : MonoBehaviour
{

    [SerializeField] Image fadeImg;

    //public UnityEvent onFadeFinish;
    bool onFadeComplete;
/*    public bool OnFadeComplete { get { return onFadeComplete; } }*/

    public UnityEvent onStart;
    public UnityEvent OnFadeComplete;

    void Awake()
    {
        Color t = fadeImg.color;
        t.a = 1;
        fadeImg.color = t;
    }

    void Start()
    {
        onStart.Invoke();
    }

    public void Wait(float dur)
    {
        //FadeCoroutine = StartCoroutine(IeFadeOut(dur));
        StartCoroutine(IeWait(dur));
    }

    public void FadeIn(float dur)
    {
        //FadeCoroutine = StartCoroutine(IeFadeIn(dur));
        fadeImg.gameObject.SetActive(true);
        StartCoroutine(FadeImage(false, dur));
    }

    public void FadeOut(float dur)
    {
        //FadeCoroutine = StartCoroutine(IeFadeOut(dur));
        fadeImg.gameObject.SetActive(true);
        StartCoroutine(FadeImage(true, dur));
    }

    public IEnumerator IeWait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    IEnumerator FadeImage(bool fadeOut, float duration)
    {
        if (fadeOut)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime / duration)
            {
                fadeImg.color = new Color(0, 0, 0, i);
                yield return null;
                onFadeComplete = false;
            }

            OnFadeComplete.Invoke();
            onFadeComplete = true;
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime / duration)
            {
                fadeImg.color = new Color(0, 0, 0, i);
                onFadeComplete = false;
                yield return null;
            }
            OnFadeComplete.Invoke();
            onFadeComplete = true;
        }
    }
}
