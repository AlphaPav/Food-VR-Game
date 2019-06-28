using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRotate : MonoBehaviour
{
    Vector3 tempEuler = new Vector3();
    float y_rotate_speed = 50f;
    float x_rotate_speed = 50f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tempEuler = transform.eulerAngles;
            tempEuler.y = tempEuler.y - y_rotate_speed * Time.deltaTime;
            transform.eulerAngles = tempEuler;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tempEuler = transform.eulerAngles;
            tempEuler.y = tempEuler.y + y_rotate_speed * Time.deltaTime;
            transform.eulerAngles = tempEuler;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            tempEuler = transform.eulerAngles;
            tempEuler.x = tempEuler.x - x_rotate_speed * Time.deltaTime;
            transform.eulerAngles = tempEuler;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempEuler = transform.eulerAngles;
            tempEuler.x = tempEuler.x + x_rotate_speed * Time.deltaTime;
            transform.eulerAngles = tempEuler;
        }

    }
}
