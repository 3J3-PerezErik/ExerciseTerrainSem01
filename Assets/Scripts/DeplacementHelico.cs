using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeplacementHelico : MonoBehaviour
{
    public float vitesseAvant;
    public float vitesseAvantMax;
    public float vitesseTourne;
    public float vitesseMonte; 

    public GameObject refHeliceAvant;
    public GameObject refHeliceArriere;
    float forceRotation;
    float forceMonte;
    public float forceAcceleration;
    Boolean finJeu;
    public GameObject explosion;
    public AudioClip sonCollecte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(!finJeu){
        //Rotation de l'hélico
        forceRotation = Input.GetAxis("Horizontal");  
        forceRotation*=vitesseTourne;

        //Mouvement vertical de l'hélico (monte ou descend)
        forceMonte = Input.GetAxis("Vertical");
        forceMonte *=vitesseMonte;
        
        //Pour augmenter vitesse avant
        if(Input.GetKey(KeyCode.E) && vitesseAvant < vitesseAvantMax){
          vitesseAvant+=forceAcceleration;
        }
        //Pour diminuer vitesse avant
        else if(Input.GetKey(KeyCode.Q) && vitesseAvant>0){
          vitesseAvant-=forceAcceleration;
        }
        transform.localEulerAngles =  new Vector3(0f , transform.localEulerAngles.y ,0f);

        //Ajuster le volume et pitch en fonction de la vitesse de  l'hélice
        if(refHeliceAvant.GetComponent<TourneHelice>().moteurEnMarche){
          GetComponent<AudioSource>().Play();
          GetComponent<AudioSource>().volume = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
          if(GetComponent<AudioSource>().pitch<=1){
            GetComponent<AudioSource>().pitch = 0.5f + refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
          }
        }
        else{
          GetComponent<AudioSource>().volume = refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
          if(GetComponent<AudioSource>().pitch>=0.5f){
            GetComponent<AudioSource>().pitch =refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y / refHeliceAvant.GetComponent<TourneHelice>().vitesseTourneMaximale;
          }
        }
        if(Input.GetKeyDown(KeyCode.M)){
          AudioListener.pause = !AudioListener.pause;
        } 
      }
      else{
        Invoke("FinDuJeu", 8f);
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

    private void OnCollisionEnter(Collision infosCollision){
      if(infosCollision.gameObject.name == "Terrain"){
        finJeu=true;
        explosion.SetActive(true);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().drag = 0.5f;
        GetComponent<Rigidbody>().angularDrag = 0.5f;
        GetComponent<Rigidbody>().freezeRotation = false;
        refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y = 0f;
        refHeliceArriere.GetComponent<TourneHelice>().vitesseTourne.y = 0f;
        GetComponent<AudioSource>().Stop();
      }
    }
    private void OnTriggerEnter(Collider infosCollision){
      if(infosCollision.gameObject.tag =="bidon"){
        Destroy(infosCollision.gameObject);
         GetComponent<AudioSource>().PlayOneShot(sonCollecte);
      }
    }
    void FinDuJeu(){
        // relance la scène
        SceneManager.LoadScene("SceneTerrain");

    }

    public void ExplosionHelico(){
      finJeu=true;
      explosion.SetActive(true);
      GetComponent<Rigidbody>().useGravity = true;
      GetComponent<Rigidbody>().drag = 0.5f;
      GetComponent<Rigidbody>().angularDrag = 0.5f;
      GetComponent<Rigidbody>().freezeRotation = false;
      refHeliceAvant.GetComponent<TourneHelice>().vitesseTourne.y = 0f;
      refHeliceArriere.GetComponent<TourneHelice>().vitesseTourne.y = 0f;
      GetComponent<AudioSource>().Stop();
    } 
}
