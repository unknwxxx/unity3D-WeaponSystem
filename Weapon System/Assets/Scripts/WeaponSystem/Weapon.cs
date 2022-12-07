using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform muzzle;

    private float timeSinceLastShot;

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private void Start()
    {
        PlayerShoot.shoowInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    private bool CanShoot() => !weaponData.isReloading && timeSinceLastShot > 1f / (weaponData.fireRate / 60f);


    public void StartReload()
    {
        if(!weaponData.isReloading)
        {
            StartCoroutine(Reload());
        }
    }


    private IEnumerator Reload()
    {
        weaponData.isReloading = true;

        yield return new WaitForSeconds(weaponData.reloadTime);

        weaponData.currentAmmo += weaponData.magSize;

        weaponData.isReloading = false;

    }

    public void Shoot()
    {
        if (weaponData.currentAmmo > 0)
        {
            if(CanShoot())
            {
                if(Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, weaponData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(weaponData.damage);
                }

                weaponData.currentAmmo--;
                timeSinceLastShot = 0;
                OnWeaponShot();
            }
        }
    }

    private void OnWeaponShot()
    {
    }
}
