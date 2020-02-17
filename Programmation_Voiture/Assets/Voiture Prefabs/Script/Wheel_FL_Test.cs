using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_FL_Test : MonoBehaviour
{
    private WheelCollider Wheel_Collider_FL;
    public static bool Wheel_FL_Plancher;
    public static bool Wheel_FL_Mur_Avant;
    public static bool Wheel_FL_Mur_Droit;
    public static bool WheeL_FL_Mur_Gauche;
    public static bool Wheel_FL_Mur_Arriere;
    public static bool Wheel_FL_Plafond;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Plancher")
        {
            Wheel_FL_Plancher = true;
            Wheel_FL_Mur_Droit = false;
            Wheel_FL_Mur_Arriere = false;
            Wheel_FL_Mur_Avant = false;
            WheeL_FL_Mur_Gauche = false;
            Wheel_FL_Plafond = false;
        }
        else if(collision.gameObject.transform.tag == "Mur Avant")
        {
            Wheel_FL_Plancher = false;
            Wheel_FL_Mur_Droit = false;
            Wheel_FL_Mur_Arriere = false;
            Wheel_FL_Mur_Avant = true;
            WheeL_FL_Mur_Gauche = false;
            Wheel_FL_Plafond = false;
        }
        else if(collision.gameObject.transform.tag == "Mur Droit")
        {
            Wheel_FL_Plancher = false;
            Wheel_FL_Mur_Droit = true;
            Wheel_FL_Mur_Arriere = false;
            Wheel_FL_Mur_Avant = false;
            WheeL_FL_Mur_Gauche = false;
            Wheel_FL_Plafond = false;
        }
        else if (collision.gameObject.transform.tag == "Mur Gauche")
        {
            Wheel_FL_Plancher = false;
            Wheel_FL_Mur_Droit = false;
            Wheel_FL_Mur_Arriere = false;
            Wheel_FL_Mur_Avant = false;
            WheeL_FL_Mur_Gauche = false;
            Wheel_FL_Plafond = false;
        }
        else if (collision.gameObject.transform.tag == "Mur Arrière")
        {

        }
        else if (collision.gameObject.transform.tag == "Plafond")
        {

        }

    }
}
