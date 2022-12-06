using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shoowInput;


    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            shoowInput?.Invoke();
        }
    }
}
