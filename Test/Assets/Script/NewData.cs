using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class NewData : MonoBehaviour 
{
    FileStream MyData = null;//我的資料
    StreamWriter MyDataPan = null;//我的筆
    int i = 0;
	void Start () 
    {
        MyData = new FileStream(Application.persistentDataPath + "/Data.txt", FileMode.OpenOrCreate);//讀取資料
        MyDataPan = new StreamWriter(MyData);//設定一枝筆在資料上
        MyDataPan.Close();
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
    public void NewWrite()//存檔
    {
        MyData = new FileStream(Application.persistentDataPath + "/Data.txt", FileMode.OpenOrCreate);//讀取資料
        MyDataPan = new StreamWriter(MyData);//設定一枝筆在資料上
        MyDataPan.WriteLine("1");//寫入血量
        MyDataPan.WriteLine("1");//寫入技能一
        MyDataPan.WriteLine("0");//寫入技能二
        MyDataPan.WriteLine("0");//寫入技能三
        MyDataPan.WriteLine("0");//寫入技能四
        MyDataPan.WriteLine("10");//寫入現有點數
        MyDataPan.WriteLine("10");//寫入總點數
        MyDataPan.WriteLine("0");//寫入
        MyDataPan.WriteLine("0");//寫入
        MyDataPan.WriteLine("0");//寫入
        MyDataPan.Close();
        Application.LoadLevel(3);//跳到場景三
    }
    public void TextData()
    {
        MyData = new FileStream(Application.persistentDataPath + "/Data.txt", FileMode.OpenOrCreate);//讀取資料
        MyDataPan = new StreamWriter(MyData);//設定一枝筆在資料上
        MyDataPan.WriteLine("1");//寫入血量
        MyDataPan.WriteLine("5");//寫入技能一
        MyDataPan.WriteLine("5");//寫入技能二
        MyDataPan.WriteLine("5");//寫入技能三
        MyDataPan.WriteLine("5");//寫入技能四
        MyDataPan.WriteLine("71");//寫入現有點數
        MyDataPan.WriteLine("100");//寫入總點數
        MyDataPan.WriteLine("0");//寫入吸血
        MyDataPan.WriteLine("10");//寫入回魔
        MyDataPan.WriteLine("0");//寫入
        MyDataPan.Close();
        Application.LoadLevel(3);//跳到場景三
    }
}
