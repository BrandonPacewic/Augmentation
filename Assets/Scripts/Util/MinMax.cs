// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using UnityEngine;

[System.Serializable]
public class IntMinMax
{
    public int Min;
    public int Max;

    public int GetValue()
    {
        return Random.Range(Min, Max + 1);
    }
}

public class FloatMinMax
{
    public float Min;
    public float Max;

    public float GetValue()
    {
        return Random.Range(Min, Max);
    }
}
