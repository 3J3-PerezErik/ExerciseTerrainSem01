using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particules : MonoBehaviour
{
    public ParticleSystem systemeParticules;
    private ParticleSystem.EmissionModule systemeParticulesEmission;
    public int nbParticules;
    void Start()
    {
        systemeParticulesEmission = systemeParticules.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            nbParticules++;
        }
        else if(Input.GetKey(KeyCode.DownArrow) && nbParticules > 0)
        {
            nbParticules--;
        }
        systemeParticulesEmission.rateOverTime = nbParticules;
    }
}
