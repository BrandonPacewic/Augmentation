// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignCameraWithCanvas : MonoBehaviour
{
    public Canvas MainCanvas;

    private void Start()
    {
        Vector3 canvasCenter = MainCanvas.GetComponent<RectTransform>().position - new Vector3(MainCanvas.GetComponent<RectTransform>().rect.width/2, MainCanvas.GetComponent<RectTransform>().rect.height/2, 0);
        Camera.main.transform.position = new Vector3(canvasCenter.x, canvasCenter.y, Camera.main.transform.position.z);
    }
}
