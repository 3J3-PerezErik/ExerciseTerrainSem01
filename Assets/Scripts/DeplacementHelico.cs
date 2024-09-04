using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    float vitesseAvant = 0f;
    float vitesseAvantMax = 10000f;
    float vitesseTourne = 1000f;
    float vitesseMonte = 1000f; 

    public GameObject refHeliceAvant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float valeurAxeH = Input.GetAxis("Horizontal");  
      vitesseTourne *= valeurAxeH;

      float valeurAxeV = Input.GetAxis("Vertical");
      vitesseMonte *=valeurAxeV;
      
      if(Input.GetKeyDown(KeyCode.E)){
        if(vitesseAvant < vitesseAvantMax){
            vitesseAvant+=5;
        }
      }
      else if(Input.GetKeyDown(KeyCode.Q)){
        if(vitesseAvant>0){
            vitesseAvant-=5;
        }
      }
    }

    void FixedUpdate(){

        var vitesseHeliceAvantActuelle = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne;
        var vitesseHeliceAvantMaximale = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;

        if(vitesseHeliceAvantActuelle.y==vitesseHeliceAvantMaximale){
            GetComponent<Rigidbody>().useGravity = false;

            GetComponent<Rigidbody>().AddRelativeTorque(0f, vitesseTourne, 0f);
            GetComponent<Rigidbody>().AddRelativeForce(0f,vitesseMonte,vitesseAvant);

            transform.localEulerAngles =  new Vector3(0f , transform.localEulerAngles.y ,0f);
        }
        else if(refHeliceAvant.GetComponent<TourneHelice>().moteurEnMarche==false){
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
