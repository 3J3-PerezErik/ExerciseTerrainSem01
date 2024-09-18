using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Compteur : MonoBehaviour
{
    // A définir dans l'inspecteur (zone de texte)
    public TextMeshProUGUI zoneTexte;
    // valeur du compteur au départ
    public int valCompteur = 120;

    public GameObject helico;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("CompteurSecondes", 1, 1);
    }

    void CompteurSecondes(){
        if(valCompteur>0){
            valCompteur -=1;
            zoneTexte.text = valCompteur.ToString();
        }
        else{
            CancelInvoke("CompteurSecondes");
            helico.GetComponent<DeplacementHelico>().ExplosionHelico(); 
        }
    }
}
