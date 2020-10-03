﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    private Text ui_pontos;
    private Text ui_vidas;

    private PlayerScript playerScript;

    private void Start()
    {
        ui_pontos = GameObject.Find("HUD/Pontos/Text").GetComponent<Text>();
        ui_vidas = GameObject.Find("HUD/Vidas/Text").GetComponent<Text>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        UpdateUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)){
            playerScript.addPoints(10);
        }
        if(Input.GetKeyDown(KeyCode.B)){
            playerScript.takeDamage();
        }
    }

    public void UpdateUI(){
        ui_pontos.text = PlayerStatus.Pontos.ToString();
        ui_vidas.text = "x " + (PlayerStatus.Vidas >= 0 ? PlayerStatus.Vidas.ToString() : 0.ToString());
    }


}