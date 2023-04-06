// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using UnityEngine;

[System.Serializable]
public class MapLayer
{
    public NodeType nodeType; // TODO: Conform to naming convention.

    public float MinDistanceFromPreviousLayer = 3.0f;
    public float MaxDistanceFromPreviousLayer = 3.0f;

    public float nodesApartDistance; // TODO: Conform to naming convention.

    [Range(0.0f, 1.0f)] 
    public float RandomizePosition = 0.0f;

    [Range(0.0f, 1.0f)]
    public float RandomizeNodes = 0.0f;

    [HideInInspector]
    public FloatMinMax distanceFromPreviousLayer => new FloatMinMax(MinDistanceFromPreviousLayer, MaxDistanceFromPreviousLayer);
}
