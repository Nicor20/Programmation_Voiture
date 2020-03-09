using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Voiture : MonoBehaviour
{
    public Transform CarToFollow;
    private Vector3 CamPos;
    private Quaternion CamRot;
    private Vector3 offset;
    private float followSpeed;
    private float lookSpeed;

    private bool LookAt;
    private bool MoveTo;
    private bool CamTop;
    private bool CamChase;
    private bool CamDriver;

    public Camera CameraMultiple;
    public Camera CameraDriver;




    private void Start()
    {
        followSpeed = 10;
        lookSpeed = 10;

        LookAt = true;
        MoveTo = true;
        CamTop = false;
        CamChase = true;
        CamDriver = false;

        CameraMultiple.enabled = true;
        CameraDriver.enabled = false;

    }

    public void LookAtTarget()
    {
        if(LookAt == true)
        {
            Vector3 _lookDirection = CarToFollow.position - transform.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
        }
        
    }

    public void MoveToTarget()
    {
        if(MoveTo == true)
        {
            Vector3 _targetPos = CarToFollow.position + 
                                 CarToFollow.forward * offset.z +
                                 CarToFollow.right * offset.x +
                                 CarToFollow.up * offset.y;
            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
        //LookAtTarget();
        //MoveToTarget();
        //ChangerCamera();
        ChoixCamera();

        if (CameraMultiple.enabled == true)
        {
            if (CamChase == true)
            {
                //Camera de poursuite

                //Position de la camera
                CamPos.x = CarToFollow.position.x - (15f * Mathf.Sin(CarToFollow.transform.eulerAngles.y * Mathf.PI / 180));
                CamPos.y = 10f + CarToFollow.position.y;
                CamPos.z = CarToFollow.position.z - (15f * Mathf.Cos(CarToFollow.transform.eulerAngles.y * Mathf.PI / 180));
                transform.position = Vector3.Lerp(transform.position, CamPos, 8f * Time.deltaTime);

                //Rotation de la camera           
                var rot = transform.rotation.eulerAngles;
                rot.x = 30f;
                rot.y = CarToFollow.transform.localEulerAngles.y;
                rot.z = 0;
                transform.rotation = Quaternion.Euler(rot);
            }
            else if (CamTop == true)
            {
                //Camera avec une vue du haut.

                //Position de la camera
                CamPos.x = CarToFollow.position.x;
                CamPos.y = 30f + CarToFollow.position.y;
                CamPos.z = CarToFollow.position.z;
                transform.position = Vector3.Lerp(transform.position, CamPos, 8f * Time.deltaTime);

                //Rotation de la camera           
                var rot = transform.rotation.eulerAngles;
                rot.x = 90f;
                rot.y = CarToFollow.transform.localEulerAngles.y;
                rot.z = 0;
                transform.rotation = Quaternion.Euler(rot);


            }
        }
    }



    void ChoixCamera()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CameraMultiple.enabled = true;
            CameraDriver.enabled = false;
            CamChase = true;
            CamTop = false;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CameraMultiple.enabled = true;
            CameraDriver.enabled = false;
            CamChase = false;
            CamTop = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            CameraMultiple.enabled = false;
            CameraDriver.enabled = true;
            CamChase = false;
            CamTop = false;
        }

    }








        
    /*
    private void Update()
    {
        if (CamTop == true)
        {
            followSpeed = 3;

            LookAt = false;
            MoveTo = false;
            var rot = transform.rotation.eulerAngles;
            rot.y = CarToFollow.transform.eulerAngles.y;
            rot.x = CarToFollow.transform.eulerAngles.x + 90;
            rot.z = CarToFollow.transform.eulerAngles.z;
            transform.rotation = Quaternion.Euler(rot);

            var pos = transform.position;
            pos.x = CarToFollow.transform.position.x;
            pos.y = CarToFollow.transform.position.y + 30f;
            pos.z = CarToFollow.transform.position.z;
            transform.position = pos;
        }
        else if (CamChase == true)
        {
            
            
            LookAt = true;
            MoveTo = true;


 var rot = transform.rotation.eulerAngles;
            rot.y = CarToFollow.transform.localEulerAngles.y;
            rot.x = CarToFollow.transform.localEulerAngles.x + 35;
            rot.z = CarToFollow.transform.localEulerAngles.z;
            transform.rotation = Quaternion.Euler(rot);
            
            followSpeed = 10;
            offset.x = 0;
            offset.y = 5;
            offset.z = -8;
            LookAt = true;
            MoveTo = true;

           



            var pos = transform.position;
            pos.x = CarToFollow.transform.position.x;
            pos.y = CarToFollow.transform.position.y + 5;
            pos.z = CarToFollow.transform.position.z - 8f;
            transform.position = pos;

        }
        else if (CamDriver == true)
        {
            followSpeed = 5;
            offset.x = 0;
            offset.y = 1.5f;
            offset.z = 0.5f;
            LookAt = false;
            MoveTo = true;
            var rot = transform.rotation.eulerAngles;
            rot.x = CarToFollow.transform.localEulerAngles.x;
            transform.rotation = Quaternion.Euler(rot);
        }
                  
    }

    private void ChangerCamera()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CamChase = true;
            CamTop = false;
            CamDriver = false;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CamTop = true;
            CamChase = false;
            CamDriver = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {  
            CamTop = false;
            CamDriver = true;
            CamChase = false;
        }
    }
    */
}
