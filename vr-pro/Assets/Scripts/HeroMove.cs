using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    //在场景中鼠标点击地面后，角色可以移动到目标位置
   
    public static Vector3 target;
    public static Vector3 source;
    public static bool isMoveOver = true;
    public float speed=2f;
    public static bool canMove = true;
    void Start()
    {
    }

    void Update()
    {
        MoveTo(target);

    }
    //让角色移动到目标位置
    private void MoveTo(Vector3 tar)
    {
        if (!isMoveOver)
        {
            Debug.Log("MoveTo");
            Vector3 offSet = tar - transform.position;

            float target_ratio = 1 - Vector3.Distance(tar, this.transform.position) / Vector3.Distance(tar, source);
            float speed = (float)((target_ratio + 0.2) * (1 - target_ratio));

            this.GetComponent<Rigidbody>().velocity = offSet.normalized * speed * 20f * Mathf.Sqrt(Vector3.Distance(tar, source));

            if (Vector3.Distance(tar, this.transform.position) < 0.2f)
            {
                isMoveOver = true;
                this.transform.position = tar;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }

        }
    }


}
