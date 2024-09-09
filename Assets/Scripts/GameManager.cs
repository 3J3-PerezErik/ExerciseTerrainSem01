using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CameraFPS;
    public GameObject Camera3emeP;
    public GameObject CameraDistanceFixe;
    public GameObject CameraSurveillance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Camera.main.gameObject.SetActive(false);
            CameraFPS.SetActive(true);
        }  

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Camera.main.gameObject.SetActive(false);
            Camera3emeP.SetActive(true);
        }  

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Camera.main.gameObject.SetActive(false);
            CameraDistanceFixe.SetActive(true);
        }  

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            Camera.main.gameObject.SetActive(false);
            CameraSurveillance.SetActive(true);
        }  
    }
}
