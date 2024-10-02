using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDome : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            GetComponent<Animator>().SetBool("ouvertureDome", true);
        }
        else if(Input.GetKeyDown(KeyCode.F)){
            GetComponent<Animator>().SetBool("ouvertureDome", false);
        }
    }
    void JoueSon(AudioClip sonDome){
        GetComponent<AudioSource>().PlayOneShot(sonDome);
    }
}
