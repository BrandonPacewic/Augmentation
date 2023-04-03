// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSwap : MonoBehaviour
{
    public string SceneName;

    public void OnButtonClick()
    {
        Debug.Log("Starting to load scene: " + SceneName);
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
