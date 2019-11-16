using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTwo : MonoBehaviour 
{
    private Skill skill;//宣告程式碼
    public GameObject MySkill;//宣告放此程式碼的物件
    private SkillRead skillReader;//宣告程式碼
    public GameObject Reader;//宣告放此程式碼的物件

    int tapCount = 0;//宣告現在螢幕有幾個手指
    Touch myTouchFinger;//宣告手指編號
    int oldTap = 0;//宣告上一個點擊數
    float myTimer = 0.0f;//我的計時器
    bool checkCount = false;//宣告是否確定連點結束
    bool twoFinger = false;//宣告是否為兩個手指
    public Text Mytap;//宣告測試
    public Text Myfingertap;//宣告測試
    public Text MyOldTap;//宣告測試
	// Use this for initialization
	void Start () 
    {
        twoFinger = false;//宣告是否為兩個手指
        tapCount = 0;//宣告現在螢幕有幾個手指
        oldTap = 0;//宣告上一個點擊數
        myTimer = 0.0f;//我的計時器
        checkCount = false;//宣告是否確定連點結束
        skillReader = Reader.GetComponent<SkillRead>();//讀取FireMS程式碼在AttackRange物件上的資料
        skill = MySkill.GetComponent<Skill>();//讀取Skill程式碼在MySkill物件上的資料
	}
	
	// Update is called once per frame
	void Update () 
    {
        tapCount = Input.touchCount;//現在有幾個手指
        Mytap.text = "TapCount==" + tapCount.ToString();//顯示現在有幾個手指
        if (tapCount >= 2)
        {
            CountMyFinger();//計算手指
        }        
	}
    void CountMyFinger()//計算手指數
    {
        for (int i = 0; i < tapCount; i++)
        {
            if (i == 1)//如果有兩個手指
            {
                myTouchFinger = Input.GetTouch(i);//把最後一個手指加進來
                Myfingertap.text = "myTouchFinger.tapCount==" + myTouchFinger.tapCount.ToString();//顯示點幾下
            }
            /*myTouchFinger.fingerId手指編號*/
        }
        if ((tapCount == 2) || (twoFinger == true))//如果只有兩根手指
        {
            twoFinger = true;//開始
            if (oldTap != myTouchFinger.tapCount)//如果上一次的點擊數不是這次的點擊數
            {
                checkCount = true;//正在連點
                oldTap = myTouchFinger.tapCount;//讓兩者相等
            }
            else
            {
                Mytimer();//進入計時器倒數後放招
            }
        }
        else
        {
            TapNumberSkill(0);//進入手勢模式
        }
        MyOldTap.text = "OldTap==" + oldTap.ToString();//顯示上一個TAP
    }
    void TapNumberSkill(int count)//用點擊代替手勢
    {
        if (count == 1)//普功
        {
            skill.clickStart = true;//可以普功
        }
        else if ((count == 2) && (skill.MP.fillAmount > 0.15f) && (int.Parse(skillReader.newData[2]) >= 1))//一技
        {
            skill.shieldSkillStart = true;
        }
        else if ((count == 3) && (skill.MP.fillAmount > 0.3f) && (int.Parse(skillReader.newData[3]) >= 1))//二技
        {
            skill.maxSkillStart = true;//可以釋放
        }
        else if ((count == 4) && (skill.MP.fillAmount > 0.5f) && (int.Parse(skillReader.newData[4]) >= 1))//大絕
        {
            skill.bigSkillStart = true;//可以釋放
        }
        oldTap = 0;//歸零
    }
    void Mytimer()
    {
        if (checkCount)//如果連點了
        {//計算時間
            if (myTimer >= 0.5f)//如果超過一秒都沒有繼續點
            {
                TapNumberSkill(oldTap);//進入點擊模式
                twoFinger = false;//結束模式
                checkCount = false;//結束連點
                myTimer = 0.0f;//歸零                
            }
            else
            {
                myTimer += Time.deltaTime;//加一個單位時間
            }
        }
    }
}
