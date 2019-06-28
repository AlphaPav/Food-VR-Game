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
 

    // Start is called before the first frame update
    void Start()
    {
        BindUIs();
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
            info_obj_text.text = "Object Info: none" + LeftHandCtrl.infoObject.name;
        }

        current_state.text = "Current Step: " + (StateControl.getStateName());
        next_state.text = "Next Step: " + StateControl.getNextStateName();

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