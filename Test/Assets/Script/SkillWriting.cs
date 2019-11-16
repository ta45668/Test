using UnityEngine;
using System.IO;
using System.Collections;

public class SkillWriting : MonoBehaviour 
{
    private SkillRead skillReader;//宣告程式碼
    public GameObject Reader;//宣告放此程式碼的物件

    FileStream MyData = null;//我的資料
    StreamWriter MyDataPan = null;//我的筆
    int i = 0;
	// Use this for initialization
	void Start () 
    {
        skillReader = Reader.GetComponent<SkillRead>();//讀取FireMS程式碼在AttackRange物件上的資料
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
    public void Write()//存檔
    {
        MyData = new FileStream(Application.persistentDataPath + "/Data.txt", FileMode.OpenOrCreate);//讀取資料
        MyDataPan = new StreamWriter(MyData);//設定一枝筆在資料上
        for (i = 0; i < 10; i++)
        {
            MyDataPan.WriteLine(skillReader.newData[i]);//寫入
        }
        MyDataPan.Close();
    }
}
