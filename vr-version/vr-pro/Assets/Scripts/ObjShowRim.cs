using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjShowRim : MonoBehaviour
{
    public Shader rimShader;
    public Color selectedColor= new Color(0.8f, 0.8f, 0, 1);

    public Color scannedColor= new Color(1.0f, 1.0f, 1);

    public bool isSelected = false;
    public bool isScaned = false;

    private Shader myShader;
    private Color myColor;
    public bool isInit = false;

    // Use this for initialization
    void Awake()
    {
        GetInitShaderAndColor();
        rimShader = Shader.Find("Hidden/RimLightSpce");
        if (!rimShader)
        {
            Debug.Log("! rimShader");
        }
        isInit = true;
    }
    private void Update()
    {
    
    }

    public void OnSelectEnter() {
        isSelected = true;
        ChangeShaderAndColor(transform, rimShader, selectedColor, false);
    }
    public void OnSelectExit()
    {
        isSelected = false;
        ChangeShaderAndColor(transform, myShader, myColor, true);
      
    }

    public void OnScanEnter()
    {

        if (isSelected) return; //select 优先级比 scan高 
        if (isScaned) return;
        ChangeShaderAndColor(transform, rimShader, scannedColor, false);
        isScaned = true;
    }
    public void OnScanExit()
    {
        if (isSelected) return; //select 优先级比 scan高 
        
        ChangeShaderAndColor(transform, myShader, myColor, true);
        isScaned = false;
    }

    private void ChangeShaderAndColor(Transform _trans, Shader _shader,Color _color, bool _isToInit)
    {
      
        if (_trans.childCount == 0) {
            //如果没有子物体，默认本物体就是整个模型         
            _trans.GetComponent<Renderer>().material.shader = _shader;
            if (_isToInit) _trans.GetComponent<Renderer>().material.color = _color; //恢复到初始颜色
            else _trans.GetComponent<Renderer>().material.SetColor("_RimColor", _color); //改shader颜色
        }
        else {
            _trans.GetComponent<Renderer>().material.shader = _shader;
            if (_isToInit) _trans.GetComponent<Renderer>().material.color = _color; //恢复到初始颜色
            else _trans.GetComponent<Renderer>().material.SetColor("_RimColor", _color); //改shader颜色

            //修改子物体 ..TODO 改成层级递归
            foreach (Transform child in _trans)
            {
                Debug.Log(child.name);
                child.GetComponent<Renderer>().material.shader = _shader;
                if (_isToInit) child.GetComponent<Renderer>().material.color = _color; //恢复到初始颜色
                else child.GetComponent<Renderer>().material.SetColor("_RimColor", _color); //改shader颜色
            }
        }

    }

    private void GetInitShaderAndColor()
    {
        if (transform.childCount== 0)
        {
            myColor = GetComponent<Renderer>().material.color;
            myShader = GetComponent<Renderer>().material.shader;
        }else 
        {
            myColor = GetComponent<Renderer>().material.color;
            myShader = GetComponent<Renderer>().material.shader;
            foreach (Transform child in transform)
            {
                myColor = child.GetComponent<Renderer>().material.color;
                myShader = child.GetComponent<Renderer>().material.shader;
                //用一个子物体代表整体，所以break
                break;
            }
        }


    }




}
