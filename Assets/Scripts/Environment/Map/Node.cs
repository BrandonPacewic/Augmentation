// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

public class Node
{
    public Point Point;
    public List<Point> Incoming = new List<Point>();
    public List<Point> Outgoing = new List<Point>();

    [JsonConverter(typeof(StringEnumConverter))]
    public NodeType NodeType;
    
    public string BlueprintName;
    public Vector2 Position;

    public Node(NodeType nodeType, string blueprintName, Point point)
    {
        NodeType = nodeType;
        BlueprintName = blueprintName;
        Point = point;
    }

    public void AddIncoming(Point p)
    {
        if (Incoming.Any(element => element.Equals(p)))
        {
            return;
        }

        Incoming.Add(p);
    }

    public void AddOutgoing(Point p)
    {
        if (Outgoing.Any(element => element.Equals(p)))
        {
            return;
        }

        Outgoing.Add(p);
    }

    public void RemoveIncoming(Point p)
    {
        Incoming.RemoveAll(element => element.Equals(p));
    }

    public void RemoveOutgoing(Point p)
    {
        Outgoing.RemoveAll(element => element.Equals(p));
    }

    public bool HasNoConnections()
    {
        return Incoming.Count == 0 && Outgoing.Count == 0;
    }
}
