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

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }
        else if (ReferenceEquals(this, obj))
        {
            return true;
        }
        else if (obj.GetType() != this.GetType())
        {
            return false;
        }
        else
        {
            return Equals((Point)obj);
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (x * 397) ^ y;
        }
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }
}
