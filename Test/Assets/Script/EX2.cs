using UnityEngine;
using System.Collections;

public class EX2 : MonoBehaviour 
{
    public GameObject menu;//選單
    public GameObject bigtext;//大的閃爍字
    public GameObject smilltext;//小的閃爍字
    public GameObject gameNametext;//遊戲名字

    bool textflash = true;//是否還在閃

    float mytimer = 0.0f;//我的計時器
    float myJumptimer = 0.0f;//我的跳躍計時器
    // Use this for initialization
    /*void OnTap(TapGesture gesture)
    {//如果點擊了
        textflash = false;//不能閃字
    }*/

    void Start()
    {
        gameNametext.SetActive(true);//顯示遊戲名字
        textflash = true;//可以閃字
        menu.SetActive(false);//隱藏選單
        //初始閃字
        bigtext.SetActive(true);
        smilltext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textflash)//如果還沒點擊螢幕
        {
            Mytimer();//閃字
        }
        else//如果點了
        {//藏字
            MyJump();
            textflash = false;//不能閃字
            gameNametext.SetActive(false);
            bigtext.SetActive(false);
            smilltext.SetActive(false);
            //選單出來
            menu.SetActive(true);//讓選單出來
        }
    }
    void Mytimer()
    {
        if (mytimer >= 0.1f)//如果超過
        {
            mytimer = 0;//歸零
            if (bigtext.active)
            {
                bigtext.SetActive(false);
                smilltext.SetActive(true);
            }
            else
            {
                bigtext.SetActive(true);
                smilltext.SetActive(false);
            }
        }
        else
        {
            mytimer += Time.deltaTime;//加一個單位時間
        }
    }
    void MyJump()
    {
        if (myJumptimer >= 3.0f)//如果超過
        {
            myJumptimer = 0;//歸零
            Application.LoadLevel(1);//跳到下一個場景(選角色)
        }
        else
        {
            myJumptimer += Time.deltaTime;//加一個單位時間
        }
    }
    public void OnClick()//當按下跳起來的時候
    {
        Application.LoadLevel(1);//跳到下一個場景(選角色)
    }
}
