using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_2 : MonoBehaviour
{
    public Transform Vehicule;
    public Transform Camera;
    public Vector3 FrontView;
    public Rigidbody rb;

    private void Start()
    {
       
    }


    private void Update()
    {
        Front_View();
    }



    private void Front_View()
    {

        transform.position = new Vector3(Vehicule.position.x + FrontView.x, Vehicule.position.y + FrontView.y, Vehicule.position.z + FrontView.z);
    }
}
