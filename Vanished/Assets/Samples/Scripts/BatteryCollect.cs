﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryCollect : MonoBehaviour
{
    //default amount of charge
    public static uint charge = 0;

    //this holds the hud images
    public static Image chargeUI;

    //Battery sprites
    public Sprite charge1tex;
    public Sprite charge2tex;
    public Sprite charge3tex;
    public Sprite charge4tex;
    public Sprite charge0tex;

    // Start is called before the first frame update
    void Start()
    {
        //find the HUD ChargeUI GameObject
        chargeUI = gameObject.GetComponentInChildren<Image>();
        //Hide the HUD on start
        chargeUI.enabled = false;
        //set initial chrge amunt
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (charge == 1)
        {
            chargeUI.sprite = charge1tex;
            chargeUI.enabled = true;



        }
        else if (charge == 2)
        {
            chargeUI.sprite = charge2tex;
        }
        else if (charge == 3)
        {
            chargeUI.sprite = charge3tex;
        }
        else if (charge == 4)
        {
            chargeUI.sprite = charge4tex;
        }
        else
        {
            chargeUI.sprite = charge0tex;
        }
    }    
    
}
