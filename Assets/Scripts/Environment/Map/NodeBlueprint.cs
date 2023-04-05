// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using UnityEngine;

public enum NodeType
{
    ENEMY,
    TRADE,
    LOADING_BAR,
    CORRUPTION_AMBUSH,
    BOSS
}

[CreateAssetMenu(fileName = "NodeBlueprint", menuName = "NodeBlueprint")]
public class NodeBlueprint : ScriptableObject
{
    public Sprite Sprite;
    public NodeType NodeType;
}
