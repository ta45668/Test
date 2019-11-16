using UnityEngine;
using System;
using System.Collections;
using System.IO;//寫存檔系統必要使用

public class LineReader : MonoBehaviour
{
    protected string text = " "; // assigned to allow first line to be read below
    public String[] oringinData =new String[10];
    //public String[] newData =new String[10];
    protected int i;
    void Start () 
    {
        i=0;        

    }
    void Update ()
    {
        if (Input.GetKey(KeyCode.R))
        {
            FileStream aFile = new FileStream(Application.dataPath + "/Data.txt", FileMode.Open);//開啟TXT

            StreamReader sr = new StreamReader(aFile);//拿出筆

            while (text != null)
            {
                text = sr.ReadLine();//讀取
                oringinData[i] = text;//存放
                Debug.Log("oringinData:" + oringinData[i]);//顯示
                i++;
            }
            sr.Close();//有使用就要關掉
            aFile.Close();//有使用就要關掉
        }
    }


}
