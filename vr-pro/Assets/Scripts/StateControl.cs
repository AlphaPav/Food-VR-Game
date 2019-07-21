using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControl : MonoBehaviour
{
    public const int IDLE = 0;
    public const int GRAP_TOMATO = 1;
    public const int PUT_PAN = 2;
    public const int PAN_TO_WATER = 3;
    public const int OPEN_WATER = 4;
    public const int PAN_TO_FIRE = 5;
    public const int OPEN_FIRE = 6;
    public const int ADD_CONDIMENT = 7;
    public const int CLOSE_FIRE = 8;
    public const int POUR_INTO_BOWL = 9;
    public const int BOWL_INTO_TRAY = 10;
    public const int SET_TABLEWARE = 11;
    public const int DELIVERY = 12;
    public const int FINISHED = 13;

    static string[] orderState = {
        "IDLE", "抓番茄", "放到锅里", "拿锅去水池", "按放水开关", "拿锅去灶台", "按开火开关,等待烹煮20秒","加入调味品","及时关火","将番茄浓汤装入碗中","将碗装入餐盘","摆放餐具","送餐","完成"
    };
    static int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Do nothing
    }

    public static void nextState()
    {
        if(state + 1 < orderState.Length)
        {
            state++;
        } 
    }

    public static int getStateId()
    {
        return state;
    }

    public static string getStateName()
    {
        return orderState[state];
    }

    public static string getNextStateName()
    {
        if(state + 1 < orderState.Length)
        {
            return orderState[state + 1];
        }
        return "None";
    } 

}
