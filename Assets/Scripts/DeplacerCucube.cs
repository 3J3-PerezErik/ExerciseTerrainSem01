using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeplacerCucube : MonoBehaviour
{

    public float multplicateurForce; 
    public float multplicateurRotation;
    float forceDeplacement;
    float forceTorsion;
    public AudioClip sonCollecte;
    public GameObject explosion;

    //Gestion de l'essence
    public float niveauEssenceMax;
    public float niveauEssenceCourant;
    public Image imgNiveaauEssence;

    // Start is called before the first frame update
    void Start()
    {
        niveauEssenceCourant = niveauEssenceMax;
    }

    // On se sert de udpdate pour détecter les touches, mais on applique les forces au rigidbodies
    // dans les FixedUpdate
    void Update()
    {
        float valeurAxeV = Input.GetAxis("Vertical"); //Retourne une valeur entre -1 et 1   
        forceDeplacement =  valeurAxeV * multplicateurForce;

        float valeurAxeH = Input.GetAxis("Horizontal"); //Retourne une valeur entre -1 et 1   
        forceTorsion =  valeurAxeH * multplicateurRotation;

        GestionEssence();
    }

    // Fonction stable a 50 FPS, réservé aux objets physiques
    void FixedUpdate()
    {
        // Ici on applique la force sur le rigidbody
        // Important: on utilise seulement une fois AddRelativeForce ou AddRelativeTorque dans une FixedUpdate
        GetComponent<Rigidbody>().AddRelativeForce(0f,0f,forceDeplacement);
        GetComponent<Rigidbody>().AddRelativeTorque(0f, forceTorsion,0f);
    }

    private void OnCollisionEnter(Collision infosCollision){
        if(infosCollision.gameObject.name == "Mur"){
            explosion.SetActive(true);
            Invoke("FinDuJeu", 5f);
        }
    }
    
    private void OnTriggerEnter(Collider infosCollision){

        if(infosCollision.gameObject.tag == "objetCollecte"){
            // Destroy(infosCollision.gameObject);
            niveauEssenceCourant +=25;
            infosCollision.gameObject.SetActive(false);
            StartCoroutine(ReactiveBouleRouge(infosCollision.gameObject));
            GetComponent<AudioSource>().PlayOneShot(sonCollecte);
        }

    }

    IEnumerator ReactiveBouleRouge(GameObject quelleBoule){
        yield return new WaitForSeconds(2f);
        quelleBoule.gameObject.SetActive(true);
    }

    void FinDuJeu(){
        // relance la scène
        SceneManager.LoadScene("SceneTerrain");

    }

    void GestionEssence(){
        niveauEssenceCourant -=50 * Time.deltaTime;
        float pourcentageEssenceRestant = niveauEssenceCourant / niveauEssenceMax;

        //Ajuste la hauteur de la barre blanche qui représente le niveau d'essence
        //C'est la propriété fill amount
        imgNiveaauEssence.fillAmount = pourcentageEssenceRestant;
    }

}
