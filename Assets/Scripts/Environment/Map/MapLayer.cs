// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using UnityEngine;

public class MapLayer : MonoBehaviour
{
    public NodeType NodeType;
    public FloatMinMax DistanceFromPreviousLayer;
    public float NodesApartDistance;
    [Range(0f, 1f)]
    public float RandomizePosition;
    [Range(0f, 1f)]
    public float RandomizeNodes;
}
