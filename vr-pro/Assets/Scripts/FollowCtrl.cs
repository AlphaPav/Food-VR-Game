using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowCtrl : MonoBehaviour
{
    // Use this for initialization
    public GameObject controller;
    void Start()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;

    }
}
