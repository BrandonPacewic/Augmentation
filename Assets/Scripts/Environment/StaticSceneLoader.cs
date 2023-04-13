// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticSceneLoader : MonoBehaviour
{
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    private void Awake()
    {
        // Needed to make sure this object is not destroyed when loading a new scene
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void UnloadScene(string sceneName)
    {
        StartCoroutine(UnloadSceneAsync(sceneName));
    }

    public void UnloadAll()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            UnloadSceneAsync(scene.name);
        }
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        scenesLoading.Add(asyncLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        scenesLoading.Remove(asyncLoad);
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        scenesLoading.Add(asyncUnload);

        while (!asyncUnload.isDone)
        {
            yield return null;
        }

        scenesLoading.Remove(asyncUnload);
    }
}
