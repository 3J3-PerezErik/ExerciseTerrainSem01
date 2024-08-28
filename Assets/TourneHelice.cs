using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourneHelice : MonoBehaviour
{
    public Vector3 vitesseTourne;
    public float vitesseTourneMaximale;
    public bool moteurEnMarche;

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
                vitesseTourne.y++;
            }
        }
        else{
            if(vitesseTourne.y>0){
                vitesseTourne.y--;
            }
        }
         transform.Rotate(vitesseTourne * Time.deltaTime);
        
    }
}
