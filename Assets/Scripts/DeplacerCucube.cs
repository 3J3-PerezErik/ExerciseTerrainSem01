using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeplacerCucube : MonoBehaviour
{

     public float multplicateurForce; 
    float forceDeplacement;

    float forceTorsion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // On se sert de udpdate pour détecter les touches, mais on applique les forces au rigidbodies
    // dans les FixedUpdate
    void Update()
    {
        float valeurAxeV = Input.GetAxis("Vertical"); //Retourne une valeur entre -1 et 1   
        forceDeplacement =  valeurAxeV * multplicateurForce;

        float valeurAxeH = Input.GetAxis("Horizontal"); //Retourne une valeur entre -1 et 1   
        forceTorsion =  valeurAxeH * multplicateurForce;
    }

    // Fonction stable a 50 FPS, réservé aux objets physiques
    void FixedUpdate()
    {
        // Ici on applique la force sur le rigidbody
        // Important: on utilise seulement une fois AddRelativeForce ou AddRelativeTorque dans une FixedUpdate
        GetComponent<Rigidbody>().AddRelativeForce(0f,0f,forceDeplacement);
        GetComponent<Rigidbody>().AddRelativeTorque(0f, forceTorsion,0f);
    }
}
