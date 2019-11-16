using UnityEngine;
using System;
using System.IO;
using System.Collections;
using UnityEngine.UI;

public class OldData : MonoBehaviour 
{
    public GameObject NoData;//沒有資料

    FileInfo MyData = null;//我的資料
    StreamReader MyDataReader = null;//我的資料讀取者
    float mytimer = 0.0f;//我的計時器
    bool unhaveData = false;//是否有資料
	// Use this for initialization
	void Start () 
    {
        unhaveData = false;
        mytimer = 0.0f;
        NoData.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (unhaveData)//沒有資料
        {
            Mytimer();//顯示沒有資料
        }
	}
    public void OldWrite()//讀檔
    {
        MyData = new FileInfo(Application.persistentDataPath + "/Data.txt");//讀取資料
        MyDataReader = MyData.OpenText();
        if (MyDataReader.ReadLine() == null)
        {
            NoData.SetActive(true);
            unhaveData = true;//沒有資料
        }
        else
        {
            unhaveData = false;//有資料
            Application.LoadLevel(3);//跳到場景三
        }
        MyDataReader.Close();
    }
    void Mytimer()
    {
        if (mytimer >= 0.1f)//如果超過
        {
            NoData.SetActive(false);
            unhaveData = false;
            mytimer = 0.0f;
        }
        else
        {
            mytimer += Time.deltaTime;//加一個單位時間
        }
    }
}
