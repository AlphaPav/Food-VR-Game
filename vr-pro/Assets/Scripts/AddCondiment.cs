using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCondiment : MonoBehaviour
{
    public Collider colliderObject;
    public GameObject particle;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log(transform.rotation.eulerAngles.x);
        if (transform.rotation.eulerAngles.x > 45.0 && transform.rotation.eulerAngles.x < 90.0)
        {
            if (flag == false)
            {
                Debug.Log("add condiment");
                particle.GetComponent<ParticleSystem>().Play();
                flag = true;
            }

        }
        else
        {
            if (flag == true)
            {
                //Debug.Log("stop adding condiment");
                particle.GetComponent<ParticleSystem>().Stop();
                flag = false;
            }
           

        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.Equals(colliderObject))
    //    {
    //        if (transform.rotation.x < -225.0)
    //        {
    //            Debug.Log("add condiment");
    //            particle.GetComponent<ParticleSystem>().Play();
    //        }
    //        else
    //        {
    //            // Debug.Log("stop adding condiment");
    //            particle.GetComponent<ParticleSystem>().Stop();

    //        }
    //    }
    //}

    //private void OnTriggerStay(Collider collision)
    //{
    //    if (collision.collider.Equals(colliderObject))
    //    {
    //        if (transform.rotation.x < -225.0)
    //        {
    //            Debug.Log("add condiment");
    //            particle.GetComponent<ParticleSystem>().Play();
    //        }
    //        else
    //        {
    //            // Debug.Log("stop adding condiment");
    //            particle.GetComponent<ParticleSystem>().Stop();

    //        }
    //    }
    //}
}
