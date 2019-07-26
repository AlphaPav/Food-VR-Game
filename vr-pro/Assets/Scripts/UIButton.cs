using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
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


    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4

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
        MakeHighlight();
        CheckInput();
    }

    void CheckInput()
    {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Ray ray = new Ray(transform.position, transform.forward * 100);     //定义一个射线对象,包含射线发射的位置transform.position，发射距离transform.forward*100；  
            RaycastHit hitInfo = new RaycastHit();    //定义一个RaycastHit变量用来保存被撞物体的信息；  
            if (Physics.Raycast(ray, out hitInfo, 100))  //如果碰撞到了物体，hitInfo里面就包含该物体的相关信息；  
            {
                Debug.Log("hitinfo: " + hitInfo.collider.gameObject.name);

                if (hitInfo.collider.gameObject.tag.Equals("UI"))
                {
                    Debug.Log("hit UI");
                    if (hitInfo.collider.gameObject.name.Equals("StartButton"))
                    {
                        Debug.Log("hit StartButton");
                        Switch(1);
                        return;
                    }
                    else if (hitInfo.collider.gameObject.name.Equals("RestartButton"))
                    {
                        Debug.Log("hit RestartButton");
                        Switch(0);
                        return;
                    }


                }
            }
        }
    }



    public void Switch(int i = 1)
    {
        SceneManager.LoadScene(i);
    }

    void MakeHighlight()
    {
        Ray ray = new Ray(transform.position, transform.forward * 100);          //定义一个射线对象,包含射线发射的位置transform.position，发射距离transform.forward*100；  
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.red);  //绘制出的射线，包含发射位置，发射距离和射线的颜色；  
        RaycastHit hitInfo;                                 //定义一个RaycastHit变量用来保存被撞物体的信息；  
        if (Physics.Raycast(ray, out hitInfo, 100))         //如果碰撞到了物体，hitInfo里面就包含该物体的相关信息；  
        {
            //Debug.Log("hitinfo: " + hitInfo.collider.gameObject.name + hitInfo.collider.gameObject.tag);
            if (hitInfo.collider.gameObject.tag.Equals("UI"))
            {

                ShowLaser(hitInfo);
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
