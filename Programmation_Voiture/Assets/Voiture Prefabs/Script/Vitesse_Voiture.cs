﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitesse_Voiture : MonoBehaviour
{
    public Text txtVitesse;
    private float vitesseKMH;

    void Update()
    {
        vitesseKMH = Controle_Voiture.vitesse;

        txtVitesse.GetComponent<Text>().text = vitesseKMH.ToString("0") + "Km/h";

    }



}
