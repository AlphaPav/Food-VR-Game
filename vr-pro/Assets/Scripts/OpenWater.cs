using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class OpenWater : MonoBehaviour
{
    public Collider colliderObject;
    public GameObject particle;
    public GameObject particle2;
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        particle2.GetComponent<MeshRenderer>().material.SetColor("_SpecColor", Color.white);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (particle2.GetComponent<MeshRenderer>().enabled == true)
        {
           // Debug.Log(particle2.GetComponent<MeshRenderer>().materials[0].color);
            Color col = particle2.GetComponent<MeshRenderer>().material.GetColor("_SpecColor");
            if (col.g > 0)
            {
                col.g -= 0.0001f;
                col.b -= 0.0001f;
                Debug.Log(col);
                particle2.GetComponent<MeshRenderer>().material.SetColor("_SpecColor", col);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + " open water collider enter:" + collision.gameObject.name);
        if (collision.collider.Equals(colliderObject))
        {
            particle.GetComponent<ParticleSystem>().Play();
            //particle.GetComponent<ObiEmitter>().enabled = true;
            StartCoroutine(Show());
            //particle2.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.name + " open water trigger enter:" + collision.gameObject.name);
        if (collision.Equals(colliderObject))
        {
            particle.GetComponent<ParticleSystem>().Play();

            //particle.GetComponent<ObiEmitter>().enabled = true;

            //Debug.Log( " partical play ");
            //particle2.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(Show());

        }
    }

    private IEnumerator Show()
    {
        Debug.Log("show");
        yield return new WaitForSeconds(1.0f);
        particle2.GetComponent<MeshRenderer>().enabled = true;
        music.GetComponent<AudioSource>().Play(0);

    }
}
