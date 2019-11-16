using UnityEngine;
using System.Collections;

public class EXChoose : MonoBehaviour 
{
    public GameObject YesNoMenu;//宣告是否選擇選單
    public GameObject Pugilist;//宣告拳師
    public GameObject SwordsGirl;//宣告劍姬
    public GameObject Master;//宣告法師

    int myChoose;//我的選擇(1=拳師2=劍姬3=法師)
	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1.0f;
        //初始化模型
        Pugilist.SetActive(false);
        SwordsGirl.SetActive(false);
        Master.SetActive(false);
        YesNoMenu.SetActive(false);//讓選單先消失
        myChoose = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {	
	}
    public void ChosPugilist()//選擇拳師
    {
        Pugilist.SetActive(true);
        SwordsGirl.SetActive(false);
        Master.SetActive(false);
        YesNoMenu.SetActive(true);
        myChoose = 1;
    }
    public void ChosSwordsGirl()//選擇劍姬
    {
        Pugilist.SetActive(false);
        SwordsGirl.SetActive(true);
        Master.SetActive(false);
        YesNoMenu.SetActive(true);
        myChoose = 2;
    }
    public void ChosMaster()//選擇法師
    {
        Pugilist.SetActive(false);
        SwordsGirl.SetActive(false);
        Master.SetActive(true);
        YesNoMenu.SetActive(true);
        myChoose = 3;
    }
    public void ChoYes()//如果選擇好了
    {
        if (myChoose == 1)//如果選擇拳師
        {
            Application.LoadLevel(4);//跳到拳師場景
        }
        else if (myChoose == 2)//如果選擇劍姬
        {
            Application.LoadLevel(5);//跳到劍姬場景
        }
        else if (myChoose == 3)//如果選擇法師
        {
            Application.LoadLevel(2);//跳到法師技能場景
        }
    }
    public void ChoNo()//如果還沒選好
    {//初始化
        myChoose = 0;
        YesNoMenu.SetActive(false);
    }
    public void GoBack()//上一頁
    {
        Application.LoadLevel(0);//跳到一開始
    }
}
