using System.Collections.Generic;
using UnityEngine;


public class ParticleBall : MonoBehaviour
{
    public Color PsColor;
    private Settings settings;
    private Particles Ps;
    private List<ParticleSystem> pss;
    private void Start()
    {
        settings = Component.FindObjectOfType<Settings>();
        Ps = Component.FindObjectOfType<Particles>();
        pss = Ps.ParticleSystems;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((bool)settings.Get("particle"))
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                ContactPoint2D contact = collision.contacts[i];
                
                pss[i].transform.position = contact.point;
                var main = pss[i + 3].main;
                var shape = pss[i + 3].shape;
                main.startColor = PsColor;
                shape.rotation = new Vector3(0, 0, Vector3.Angle(Vector2.up, contact.normal));
                pss[i].gameObject.SetActive(true);
                pss[i].Play();
            }
        }
        else
        {
            /*for (int i = 0; i < collision.contactCount; i++)
            {
                ContactPoint2D contact = collision.contacts[i];

                Ps.Sparks[i].transform.position = contact.point;


                Ps.Sparks[i].transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector2.up, contact.normal), Vector3.forward);
                Ps.Sparks[i].gameObject.SetActive(true);
                Ps.SparksFx[i].Play();
            }*/
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((bool)settings.Get("particle"))
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                ContactPoint2D contact = collision.contacts[i];
                
                pss[i].transform.position = contact.point;
                var main = pss[i].main;
                var shape = pss[i].shape;
                main.startColor = PsColor;
                shape.rotation = new Vector3(0, 0, Vector3.Angle(Vector2.up, contact.normal));
                pss[i].gameObject.SetActive(true);
                pss[i].Play();
            }
        }
        else
        {
            /*for (int i = 0; i < collision.contactCount; i++)
            {
                ContactPoint2D contact = collision.contacts[i];

                Ps.Sparks[i].transform.position = contact.point;


                Ps.Sparks[i].transform.rotation = Quaternion.AngleAxis(Vector3.Angle(Vector2.up, contact.normal), Vector3.forward);
                Ps.Sparks[i].gameObject.SetActive(true);
                Ps.SparksFx[i].Play();
            }*/
        }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((bool)settings.Get("particle"))
        {
            for (int i = 0; i < collision.contactCount; i++)
            {

                pss[i].Stop();
                pss[i].gameObject.SetActive(false);

            }
        }
        else
        {
            /*for (int i = 0; i < collision.contactCount; i++)
            {

                Ps.SparksFx[i].Stop();
                Ps.Sparks[i].gameObject.SetActive(false);

            }*/
        }
    }
}
