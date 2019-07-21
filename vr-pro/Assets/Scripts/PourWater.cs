using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourWater : MonoBehaviour
{
    public Collider colliderObject;
    public GameObject particle;
    public GameObject particle2;
    public GameObject particle3;

    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation.eulerAngles.x);
        if (transform.rotation.eulerAngles.x > 40.0 && transform.rotation.eulerAngles.x < 90.0)
        {
            if (flag == false)
            {
                Debug.Log("pouring");
                particle.GetComponent<ParticleSystem>().Play();
                flag = true;
                StartCoroutine(Show());
                StartCoroutine(Show2());

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
    private IEnumerator Show()
    {
        Debug.Log("show");
        yield return new WaitForSeconds(1.0f);
        particle2.GetComponent<MeshRenderer>().enabled = true;

    }
    private IEnumerator Show2()
    {
        Debug.Log("show2");
        yield return new WaitForSeconds(3.0f);
        particle3.GetComponent<MeshRenderer>().enabled = false;
        particle.GetComponent<ParticleSystem>().Stop();
    }
}
