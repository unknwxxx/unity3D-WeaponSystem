using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    private float timeSinceLastShot;


    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private void Start()
    {
        PlayerShoot.shoowInput += Shoot;
    }

    private bool CanShoot() => !weaponData.isReloading && timeSinceLastShot > 1f / (weaponData.fireRate / 60f);

    public void Shoot()
    {
        if (weaponData.currentAmmo > 0)
        {
            if(CanShoot())
            {
                if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, weaponData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                }

                weaponData.currentAmmo--;
                timeSinceLastShot = 0;
                OnWeaponShot();
            }
        }
       
    }

    private void OnWeaponShot()
    {
        Debug.Log("Shoot");
    }
}
