using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotate : MonoBehaviour
{
    public bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight) {
            if (Input.GetKey(KeyCode.I))
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, 1), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.K))
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, -1), 60f * Time.deltaTime);//第三个参数表示角度
            }

            if (Input.GetKey(KeyCode.L))
            {
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.J))
            {
                transform.RotateAround(transform.position, new Vector3(0, -1, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.N))
            {
                transform.RotateAround(transform.position, new Vector3(-1, 0, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.M))
            {
                transform.RotateAround(transform.position, new Vector3(1, 0, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, 1), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, -1), 60f * Time.deltaTime);//第三个参数表示角度
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.RotateAround(transform.position, new Vector3(0, -1, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.Z))
            {
                transform.RotateAround(transform.position, new Vector3(-1, 0, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }
            if (Input.GetKey(KeyCode.X))
            {
                transform.RotateAround(transform.position, new Vector3(1, 0, 0), 60f * Time.deltaTime);//第三个参数表示角度
            }

        }


    }
}
