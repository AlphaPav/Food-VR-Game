using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RightHandCtrl : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    public GameObject Touchhighlightpoiont;
    public GameObject hero_controller;


    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4

    public static GameObject collidingObject; // 1
    public static GameObject objectInHand; // 2


    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;
      
    }

    // Update is called once per frame
    void Update()
    {
       
        CheckChosenObj();
    }

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        if (col.gameObject.tag != "Touchable") return;
        Debug.Log("touch :"+ col.gameObject.name);
        // 2
        collidingObject = col.gameObject;

    }


    // 1
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("right hand OnTriggerEnter: " + other.gameObject.name);
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("right hand OnTriggerStay: " + other.gameObject.name);
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
       
        if (!collidingObject)
        {
            return;
        }
        // Debug.Log("right hand OnTriggerExit: " + other.gameObject.name);

        collidingObject = null;
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        Debug.Log("GrabObject!!!!!!!!" + objectInHand.name + "OnSelectEnter");
        objectInHand.GetComponent<ObjShowRim>().OnSelectEnter();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            // GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            //objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
            //objectInHand.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = GetComponent<Rigidbody>().angularVelocity;
            //objectInHand.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 5, 0);
        }
        // 4
        objectInHand.GetComponent<ObjShowRim>().OnSelectExit();
        objectInHand = null;

    }


 

    void CheckChosenObj()
    {
        // 1
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Mouse Left Button Down");
            if (collidingObject)
            {
                Debug.Log("collidingObject");
                GrabObject();
            }
        }


        // 2
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (objectInHand)
            {
                Debug.Log("ReleaseObject");
                ReleaseObject();
            }
        }

    }


    private void ShowLaser(RaycastHit hit)
    {
        hitPoint = hit.point;
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(transform.position, hitPoint, .5f);// transform.position是世界坐标
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }




}
