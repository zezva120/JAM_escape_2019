using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    [SerializeField]
    FadeLoader fader;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void WaitBeforeLoad(string sceneName)
    {
        StartCoroutine(IeWaitBeforeLoad(sceneName));
    }

    IEnumerator IeWaitBeforeLoad(string sceneName)
    {
        fader.FadeIn(3);
        yield return new WaitForSeconds(4);
        LoadScene(sceneName);
    }
}
