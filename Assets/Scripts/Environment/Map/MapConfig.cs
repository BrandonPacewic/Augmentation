// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using Malee.List;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "MapConfig")]
public class MapConfig : ScriptableObject
{
    public List<NodeBlueprint> NodeBlueprints;
    public int GridWidth => Mathf.Max(NumOfPreBossNodes.Max, NumOfStartingNodes.Max);

    public IntMinMax NumOfPreBossNodes;
    public IntMinMax NumOfStartingNodes;

    [Tooltip("Increase this number to generate more paths")]
    public int ExtraPaths;
    public ListOfMapLayers Layers;

    [System.Serializable]
    public class ListOfMapLayers : ReorderableArray<MapLayer>
    {
    }
}
