// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapView : MonoBehaviour 
{
    public MapManager MapManager;

    public List<MapConfig> MapConfigs;
    public GameObject NodePrefab;

    [Header("Background")]
    public float StartOrientationOffset;
    public Sprite Background;
    public Color32 BackgroundColor;
    public float XSize;
    public float YSize;
    public float YOffset;

    [Header("Path")]
    public GameObject PathPrefab;
    [Range(3, 10)]
    public int LinePointCount;
    public float NodePathOffset;

    [Header("Colors")]
    public Color32 VisitedColor;
    public Color32 LockedColor;
    public Color32 PathVisitedColor;
    public Color32 PathLockedColor;

    private GameObject firstParent;
    private GameObject mapParent;
    private List<List<Point>> paths;
    private Camera mainCamera;

    [HideInInspector]
    public List<MapNode> MapNodes = new List<MapNode>();
    private List<LineConnection> lineConnections = new List<LineConnection>();

    public static MapView Instance;

    public Map Map { get; private set; }

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    public void ShowMap(Map map)
    {
        if (map == null)
        {
            Assert.Boolean(false);
        }

        Map = map;

        ClearMap();
        CreateMapParent();
        CreateNodes(map.Nodes);
        DrawLines();
        SetOrientation();
        ResetNodesRotation();
        SetAttainableNodes();
        SetLineColors();
        CreateMapBackground(map);
    }

    public void SetAttainableNodes()
    {
        foreach (var node in MapNodes)
        {
            node.SetState(NodeStates.Locked);
        }

        if (MapManager.CurrentMap.Path.Count == 0)
        {
            foreach (var node in MapNodes.Where(n => n.Node.Point.Y == 0))
            {
                node.SetState(NodeStates.Attainable);
            }
        }
        else
        {
            foreach (var point in MapManager.CurrentMap.Path)
            {
                var mapNode = GetNode(point);

                if (mapNode != null)
                {
                    mapNode.SetState(NodeStates.Visited);
                }
            }

            var currentPoint = MapManager.CurrentMap.Path.Last();
            var currentNode = MapManager.CurrentMap.GetNode(currentPoint);

            foreach (var point in currentNode.Outgoing)
            {
                var mapNode = GetNode(point);

                if (mapNode != null)
                {
                    mapNode.SetState(NodeStates.Attainable);
                }
            }
        }
    }

    public void SetLineColors()
    {
        foreach (var line in lineConnections)
        {
            line.SetColor(PathLockedColor);
        }

        if (MapManager.CurrentMap.Path.Count == 0)
        {
            return;
        }

        var currentPoint = MapManager.CurrentMap.Path.Last();
        var currentNode = MapManager.CurrentMap.GetNode(currentPoint);

        foreach (var point in currentNode.Outgoing)
        {
            var line = lineConnections.FirstOrDefault(conn => conn.from.Node == currentNode && conn.to.Node.Point == point);

            if (line != null)
            {
                line.SetColor(PathVisitedColor);
            }
        }

        if (MapManager.CurrentMap.Path.Count <= 1)
        {
            return;
        }

        for (int i = 0; i < MapManager.CurrentMap.Path.Count - 1; i++)
        {
            var current = MapManager.CurrentMap.Path[i];
            var next = MapManager.CurrentMap.Path[i + 1];
            var line = lineConnections.FirstOrDefault(conn => conn.from.Node.Point == current && conn.to.Node.Point == next);

            if (line != null)
            {
                line.SetColor(PathVisitedColor);
            }
        }
    }

    private void ClearMap()
    {
        if (firstParent != null)
        {
            Destroy(firstParent);
        }

        MapNodes.clear();
        lineConnections.clear();
    }

    private void CreateMapParent()
    {
        firstParent = new GameObject("Map");
        mapParent = new GameObject("Nodes");
        mapParent.transform.SetParent(firstParent.transform);
        var scrollNonUi = mapParent.AddComponent<ScrollNonUI>();
        scrollNonUi.freezeX = true;
        scrollNonUi.freezeY = false;
        var boxCollider = mapParent.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(100, 100, 1);
    }

    private void CreateNodes(IEnumerable<Node> nodes) {
        foreach (var node in nodes)
        {
            var mapNode = CreateMapNode(node);
            MapNodes.Add(mapNode);
        }
    }

    private CreateMapNode(Node node)
    {
        var mapNodeObject = Instantiate(NodePrefab, mapParent.transform);
        var mapNode = mapNodeObject.GetComponent<MapNode>();
        var blueprint = GetBlueprint(node.blueprintName);
        mapNode.SetUp(node, blueprint);
        mapNode.transform.localPosition = node.Position;

        return mapNode;
    }


}
