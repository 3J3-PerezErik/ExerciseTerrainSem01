using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    public float vitesseAvant;
    public float vitesseAvantMax;
    public float vitesseTourne;
    public float vitesseMonte; 

    public GameObject refHeliceAvant;

    float forceRotation;
    float forceMonte;
    public float forceAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      forceRotation = Input.GetAxis("Horizontal");  
      forceRotation*=vitesseTourne;

      forceMonte = Input.GetAxis("Vertical");
      forceMonte *=vitesseMonte;
      
      if(Input.GetKey(KeyCode.E) && vitesseAvant < vitesseAvantMax){
        vitesseAvant+=forceAcceleration;
      }
      else if(Input.GetKey(KeyCode.Q) && vitesseAvant>0){
        vitesseAvant-=forceAcceleration;
      }
      transform.localEulerAngles =  new Vector3(0f , transform.localEulerAngles.y ,0f);

      //Ajuster le volume en fonction de la vitesse de  l'hélice
      if(refHeliceAvant.GetComponent<TourneHelice>().moteurEnMarche){
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
        if(GetComponent<AudioSource>().pitch<=1){
          GetComponent<AudioSource>().pitch = 0.5f + refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
        }
      }
      else{
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().volume = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
        if(GetComponent<AudioSource>().pitch>0.5f){
          GetComponent<AudioSource>().pitch = 0.5f + refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
        }
      }
      if(Input.GetKeyDown(KeyCode.M)){
        AudioListener.pause = !AudioListener.pause;
      }
    }

    void FixedUpdate(){

        var vitesseHeliceAvantActuelle = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne;
        var vitesseHeliceAvantMaximale = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;

        if(vitesseHeliceAvantActuelle.y==vitesseHeliceAvantMaximale){
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().AddRelativeTorque(0f, forceRotation, 0f);
            GetComponent<Rigidbody>().AddRelativeForce(0f,forceMonte,vitesseAvant);
        }
        else if(refHeliceAvant.GetComponent<TourneHelice>().moteurEnMarche==false){
            GetComponent<Rigidbody>().useGravity = true;
        }
    } 
}
