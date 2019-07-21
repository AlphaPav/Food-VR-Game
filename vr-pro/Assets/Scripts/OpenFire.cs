using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFire : MonoBehaviour
{
    public Collider colliderObject;
    public GameObject particle;
    public GameObject particle2;
    public AudioClip clip1;
    public AudioClip clip2;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + " open fire collider enter:" + collision.gameObject.name);
        if (collision.collider.Equals(colliderObject))
        {
            if (flag == false)
            {
                particle.GetComponent<ParticleSystem>().Play();
                particle2.GetComponent<ParticleSystem>().Play();
                GetComponent<AudioSource>().PlayOneShot(clip1);
                GetComponent<AudioSource>().PlayOneShot(clip2);
                flag = true;

            }
            else
            {
                particle.GetComponent<ParticleSystem>().Stop();
                particle2.GetComponent<ParticleSystem>().Stop();
                GetComponent<AudioSource>().Stop();
                flag = false;
            }
            //particle.GetComponent<ObiEmitter>().enabled = true;
            //particle2.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.name + " open fire trigger enter:" + collision.gameObject.name);
        if (collision.Equals(colliderObject))
        {
            if (flag == false)
            {
                particle.GetComponent<ParticleSystem>().Play();
                particle2.GetComponent<ParticleSystem>().Play();
                GetComponent<AudioSource>().PlayOneShot(clip1);
                GetComponent<AudioSource>().PlayOneShot(clip2);
                flag = true;

            }
            else
            {
                particle.GetComponent<ParticleSystem>().Stop();
                particle2.GetComponent<ParticleSystem>().Stop();
                GetComponent<AudioSource>().Stop();
                flag = false;
            }

        }
    }
}
