using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SceneMaster : MonoBehaviour
{
    [SerializeField]
    UnityStringEvent onSceneLoaded;

    [SerializeField]
    UnityStringEvent onSceneUnloaded;

    [SerializeField]
    UnityStringEvent beforeSceneUnloaded;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name + " Mode: " + mode);
        onSceneLoaded.Invoke(scene.name);
    }

    void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded: " + scene.name);
        onSceneUnloaded.Invoke(scene.name);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

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
        beforeSceneUnloaded.Invoke(sceneName);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}
