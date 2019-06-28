using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateState : MonoBehaviour
{
    public int currentState;
    public Collider colliderObject;

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
        Debug.Log(this.name+ " update state collider enter:" + collision.gameObject.name);
        if (collision.collider.Equals(colliderObject))
        {
            if(StateControl.getStateId() == currentState)
            {
                StateControl.nextState();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.name + " update state trigger enter:" + collision.gameObject.name);
        if (collision.Equals(colliderObject))
        {
            if (StateControl.getStateId() == currentState)
            {
                StateControl.nextState();
            }
        }
    }
}
