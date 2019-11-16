using UnityEngine;
using System.Collections;
using System.IO;//寫存檔系統必要使用

public class LineWriter : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.W))
        {
            FileStream aFile = new FileStream(Application.dataPath + "/Data.txt", FileMode.Create);//創造TXT

            StreamWriter sw = new StreamWriter(aFile);//設定筆
            /*撰寫內容*/
            sw.WriteLine("为今后我们之间的进一步合作，");

            sw.WriteLine("为我们之间日益增进的友谊，");

            sw.Write("为朋友们的健康幸福，");

            sw.Write("干杯！朋友！");

            sw.Close();//有使用就要關掉
            aFile.Close();//有使用就要關掉
        }
	}
}
