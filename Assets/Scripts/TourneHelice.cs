using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourneHelice : MonoBehaviour
{
    public Vector3 vitesseTourne;
    public float vitesseTourneMaximale;
    public bool moteurEnMarche;

    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Détection de la touche entrer 

        if(Input.GetKeyDown(KeyCode.Return)){

            moteurEnMarche = !moteurEnMarche;
        }

        if (moteurEnMarche) {
            if(vitesseTourne.y<vitesseTourneMaximale){
                vitesseTourne.y+=acceleration;
            }
        }
        else{
            if(vitesseTourne.y>0){
                vitesseTourne.y-=acceleration;
                //vitesseTourne.y = Mathf.Clamp(vitesseTourne.y-= 1f, 0f, vitesseTourneMaximale);
            }
        }
         transform.Rotate(vitesseTourne * Time.deltaTime);
        
    }
}
