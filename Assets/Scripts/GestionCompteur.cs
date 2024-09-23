using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GestionCompteur : MonoBehaviour
{
   public GameObject txtCompteur;
    public int leCompteur;

    public GameObject helico;

    private IEnumerator coroutineGestionTemps;
    public void ActivationCompteur(){
        txtCompteur.SetActive(true);
        coroutineGestionTemps = Decompte();
        StartCoroutine(coroutineGestionTemps);
    }

    IEnumerator Decompte(){
        while(true){
            yield return new WaitForSeconds(1f);
            leCompteur--;
            txtCompteur.GetComponent<TextMeshProUGUI>().text = leCompteur.ToString();
            if(leCompteur == 0){
                // on fait exploser le jeu
                StopCoroutine(coroutineGestionTemps);
                helico.GetComponent<DeplacementHelico>().ExplosionHelico(); 
            }
        }
    }
}
