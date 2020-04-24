using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    float maxValue;
    float speed = 2f;
    bool fadeIn;

    public void FadeFunc(float value)
    {
        StartCoroutine(IeFade(value));
    }

    public IEnumerator IeFade(float value)
    {
        if (!fadeIn)
            while (value > 0)
            {
                value -= speed * Time.fixedDeltaTime;
                yield return null;
            }
        else
            while (value < maxValue)
            {
                value += speed * Time.fixedDeltaTime;
                yield return null;
            }
    }

    public void FadeIn()
    {

    }

    public void FadeOut()
    {

    }

    public void SetMaxValue(float _maxValue)
    {
        maxValue = _maxValue;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void SetFadeIn(bool _fadeIn)
    {
        fadeIn = _fadeIn;
    }
}
