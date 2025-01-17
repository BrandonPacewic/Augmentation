// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLine : MonoBehaviour
{
    public bool DrawLine;
    public Vector3 ChangePosition;
    public Color Color;
    public float Clear;
    public float Width = 1.0f;

    private LineRenderer line;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        line = GetComponent<LineRenderer>();
        Color[3] = Clear;
        line.startColor = Color;
        line.endColor = Color;
        line.startWidth = Width;
        line.endWidth = Width;
    }

    private void Update()
    {
        if (DrawLine)
        {
            line.SetPositions(new Vector3[] { transform.position + ChangePosition, player.position });
        }
        else
        {
            line.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
        }
    }
}
