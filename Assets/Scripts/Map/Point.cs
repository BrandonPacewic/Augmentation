// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System;

public class Point : IEquatable<Point>
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Equals(Point other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }
        else if (ReferenceEquals(this, other))
        {
            return true;
        }
        else
        {
            return x == other.x && y == other.y;
        }
    }
}
