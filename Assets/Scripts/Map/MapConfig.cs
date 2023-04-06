// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using Malee.List;
using UnityEngine;

[CreateAssetMenu]
public class MapConfig : ScriptableObject
{
    public List<NodeBlueprint> nodeBlueprints; // TODO: Conform to naming convention
    public int GridWidth => Mathf.Max(numOfPreBossNodes.max, numOfStartingNodes.max);

    public int MinPreBossNodes;
    public int MaxPreBossNodes;
    public int MinStartingNodes;
    public int MaxStartingNodes;
    public int ExtraPaths;
    
    [Reorderable]
    public ListOfMapLayers layers; // TODO: Conform to naming convention

    [System.Serializable]
    public class ListOfMapLayers : ReorderableArray<MapLayer>
    {
    }

    [HideInInspector]
    public IntMinMax numOfPreBossNodes => new IntMinMax(MinPreBossNodes, MaxPreBossNodes);
    [HideInInspector]
    public IntMinMax numOfStartingNodes => new IntMinMax(MinStartingNodes, MaxStartingNodes);
}
