// Copyright (c) TigardHighGDC
// SPDX-License SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObject/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Stats")]
    public float ReloadSpeed;
    public float BulletSpeed;
    public float BulletPerSecond;
    public int BulletPerTrigger;
    public int AmmoCapacity;
    public float Spread;
    public float Knockback;
    public float DespawnTime;
    public bool AutoReload;
    public AudioClip SoundEffect;
    public float SoundVolume;

    [Header("Effects")]
    // Effects should have a void return type and no parameters.
    public List<Action> weaponEffects;
    public List<Action> bulletEffects;
}
