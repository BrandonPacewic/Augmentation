// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Room;

    public void OnStartButton()
    {
        GameObject sceneLoader = GameObject.Find("Scene Loader");
        sceneLoader?.GetComponent<StaticSceneLoader>()?.LoadScene(Room);
    }
}
