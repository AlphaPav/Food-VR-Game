using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftHandCtrl : MonoBehaviour
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

    public GameObject Walkhighlightpoint;
    public GameObject hero_controller;

    private GameObject scanned_touchable_obj;

    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4

    public static GameObject infoObject;



    // Start is called before the first frame update
    void Start()
    {
        scanned_touchable_obj = null;
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;

    }

    // Update is called once per frame
    void Update()
    {
        MakeHighlight();
        CheckInput();
    }

    void CheckInput()
    {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            // 点击UI时不触发场景物体的响应
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("touch area is UI");
                return;
            }

            Ray ray = new Ray(transform.position, transform.forward * 100);     //定义一个射线对象,包含射线发射的位置transform.position，发射距离transform.forward*100；  
            RaycastHit hitInfo = new RaycastHit();    //定义一个RaycastHit变量用来保存被撞物体的信息；  
            if (Physics.Raycast(ray, out hitInfo, 100))  //如果碰撞到了物体，hitInfo里面就包含该物体的相关信息；  
            {
                Debug.Log("hitinfo: " + hitInfo.collider.gameObject.name);
                if (hitInfo.collider.gameObject.tag.Equals("Walkable"))
                {
                    print(" will move to a  Walkable");
                    if (Vector3.Distance(hitInfo.point, hero_controller.transform.position) < 10f
                            && Mathf.Abs(hitInfo.point[1] - hero_controller.transform.position[1]) < 10f)
                    {
                        HeroMove.target = hitInfo.point;
                        HeroMove.target.y = hero_controller.transform.position.y;
                        HeroMove.isMoveOver = false;
                        //2. 让角色移动到目标位置
                        HeroMove.source = hero_controller.transform.position;
                    }
                }else if (hitInfo.collider.gameObject.tag.Equals("Touchable")) 
                {
                    infoObject = hitInfo.collider.gameObject;
                }
            }
        }
    }

    void MakeHighlight()
    {
        Ray ray = new Ray(transform.position, transform.forward * 100);          //定义一个射线对象,包含射线发射的位置transform.position，发射距离transform.forward*100；  
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.red);  //绘制出的射线，包含发射位置，发射距离和射线的颜色；  
        RaycastHit hitInfo;                                 //定义一个RaycastHit变量用来保存被撞物体的信息；  
        if (Physics.Raycast(ray, out hitInfo, 100))         //如果碰撞到了物体，hitInfo里面就包含该物体的相关信息；  
        {
            //Debug.Log("hitinfo: " + hitInfo.collider.gameObject.name + hitInfo.collider.gameObject.tag);
            if (hitInfo.collider.gameObject.tag.Equals("Touchable"))
            {
                if (scanned_touchable_obj == null)
                {
                    scanned_touchable_obj = hitInfo.collider.gameObject;
                    scanned_touchable_obj.GetComponent<ObjShowRim>().OnScanEnter();
                }
                else if (scanned_touchable_obj != hitInfo.collider.gameObject)
                {
                    // scan到和上次不一样的物体
                    scanned_touchable_obj.GetComponent<ObjShowRim>().OnScanExit();
                    scanned_touchable_obj = hitInfo.collider.gameObject;
                    scanned_touchable_obj.GetComponent<ObjShowRim>().OnScanEnter();
                }
                ShowLaser(hitInfo);
                Touchhighlightpoiont.transform.position = hitInfo.point;
                Touchhighlightpoiont.GetComponent<MeshRenderer>().enabled = true;
                Walkhighlightpoint.GetComponent<MeshRenderer>().enabled = false;
           
            }
            else if (hitInfo.collider.gameObject.tag.Equals("Walkable"))
            {
                ShowLaser(hitInfo);
                Walkhighlightpoint.transform.position = hitInfo.point;
                Walkhighlightpoint.GetComponent<MeshRenderer>().enabled = true;
              
                if (scanned_touchable_obj != null)
                {
                    scanned_touchable_obj.GetComponent<ObjShowRim>().OnScanExit();
                    scanned_touchable_obj = null;
                }
                Touchhighlightpoiont.GetComponent<MeshRenderer>().enabled = false;

            }
            else
            {
                NoHighlightPoint();
            }
        }
        else
        {
            NoHighlightPoint();
        }
    }

    private void NoHighlightPoint()
    {
        laser.SetActive(false);
        if (scanned_touchable_obj != null)
        {
            scanned_touchable_obj.GetComponent<ObjShowRim>().OnScanExit();
            scanned_touchable_obj = null;
        }
        Walkhighlightpoint.GetComponent<MeshRenderer>().enabled = false;
        Touchhighlightpoiont.GetComponent<MeshRenderer>().enabled = false;
      
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
