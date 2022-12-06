using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName="Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public new string name;

    public float damage;
    public float maxDistance;

    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;

    [HideInInspector]
    public bool isReloading;

   
}
