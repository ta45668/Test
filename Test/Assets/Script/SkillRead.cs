using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class SkillRead : MonoBehaviour 
{
    protected FileStream MyData = null;//我的資料
    protected StreamReader MyDataReader = null;//我的資料讀取者
    protected string text = " "; // assigned to allow first line to be read below
    public String[] newData =new String[10];
	// Use this for initialization
	void Start () 
    {
        MyData = new FileStream(Application.dataPath + "/Data.txt", FileMode.Open);//開啟TXT
        MyDataReader = new StreamReader(MyData);//拿出筆
        ReadText();
        Debug.Log(Application.dataPath);
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
    void ReadText()//讀取資料到面板上
    {
        for (int i = 0; i < 10; i++)
        {
            text = MyDataReader.ReadLine();//讀取每一行資料
            newData[i] = text;
        }
        MyDataReader.Close();//關閉
        MyData.Close();
    }
}
