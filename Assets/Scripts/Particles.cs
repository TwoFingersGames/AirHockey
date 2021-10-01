
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Particles : MonoBehaviour
{
    private Settings settings;
    [SerializeField] private GameObject collParticle, goalParticle, SparkFx;
    public List<GameObject> ParticleObjects;
    public List<ParticleSystem> ParticleSystems;
    //public List<GameObject> Sparks;

    //public List<VisualEffect> SparksFx;
    
    private void Awake()
    {

        settings = Component.FindObjectOfType<Settings>();
        if ((bool)settings.Get("particle"))
        {
            InstantiateCollParticles();
        }
        else
        {
            //InstantiateSparks();
        }
        
        
    }
    private void InstantiateCollParticles()
    {
        ParticleObjects = new List<GameObject>();
        ParticleSystems = new List<ParticleSystem>();
        for (int i = 0; i < 10; i++)
        {
            GameObject collPart = Instantiate(this.collParticle);
            ParticleSystem ps = collPart.GetComponent<ParticleSystem>();
            ParticleSystems.Add(ps);
            collPart.SetActive(true);
            ParticleObjects.Add(collPart);
        }
    }
    private void InstantiateSparks()
    {
        /*Sparks = new List<GameObject>();
        SparksFx = new List<VisualEffect>();
        for (int i = 0; i < 10; i++)
        {
            GameObject spark = Instantiate(this.SparkFx);
            VisualEffect fx = spark.GetComponent<VisualEffect>();
            SparksFx.Add(fx);
            spark.SetActive(true);
            Sparks.Add(spark);
        }*/
    }




}
