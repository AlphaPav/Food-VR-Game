using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UICtrl : MonoBehaviour
{

    public Text msg_text;
    public Text current_state;
    public Text grab_obj_text;
    public Text info_obj_text;
    public Text touch_obj_text;
    public Text next_state;
    public Text total_cook_time_text;
    public Text fire_time_text;

    private float fire_time;
    private bool fire_already_closed;
    private bool cook_already_finished;

    // Start is called before the first frame update
    void Start()
    {
        BindUIs();
        fire_time = -1;
        fire_already_closed = false;
        cook_already_finished = false;
    }

    void BindUIs()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (RightHandCtrl.objectInHand == null)
        {
            grab_obj_text.text = "Grab obj: none";
        }
        else
        {
            grab_obj_text.text = "Grab obj:" + RightHandCtrl.objectInHand.name;
        }

        if (RightHandCtrl.collidingObject == null)
        {
            touch_obj_text.text = "Touch obj: none";
        }
        else
        {
            touch_obj_text.text = "Touch obj:" + RightHandCtrl.collidingObject.name;
        }

        if (LeftHandCtrl.infoObject == null)
        {
            info_obj_text.text = "Object Info: none";
        }
        else
        {
            info_obj_text.text = "Object Info: " + LeftHandCtrl.infoObject.name;
        }

        current_state.text = "已完成步骤: " + (StateControl.getStateName());
        next_state.text = "下一步: " + StateControl.getNextStateName();

        if(StateControl.getStateId() + 1 < StateControl.FINISHED)
        {
            total_cook_time_text.text = "游戏时长: " + Mathf.Round(Time.timeSinceLevelLoad) + " 秒";
        }
        else if (cook_already_finished == false)
        {
            total_cook_time_text.text = "菜肴制作完成，总烹饪耗时" + Mathf.Round(Time.time) + " 秒";
            cook_already_finished = true;
        }


        if(StateControl.getStateId() < StateControl.OPEN_FIRE)
        {
            fire_time_text.text = ""/*"尚未开始烹煮"*/;
        }
        else if(StateControl.getStateId() >= StateControl.OPEN_FIRE && StateControl.getStateId() < StateControl.CLOSE_FIRE)
        {
            if(fire_time < 0)
            {
                fire_time = Time.time;
            }
            else
            {
                fire_time_text.text = "烹煮时长: " + Mathf.Round(Time.time - fire_time) + " 秒";
            }
        }
        else if(!fire_already_closed)
        {
            fire_time_text.text = "烹煮完成，共"+ Mathf.Round(Time.time - fire_time) + "秒";
            fire_already_closed = true;
        }

    }

    public void UICtrlMsgSetString(string str)
    {
        StartCoroutine(DisplayMsg(str));
    }

    private IEnumerator DisplayMsg(string str)
    {
        msg_text.text = str;
        yield return new WaitForSeconds(2); //等待2秒后清空消息
        msg_text.text = "";
    }

}