using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestScript : MonoBehaviour
{
    [Header("讀取檔案")]
    public String[] myData = new String[10];

    private SkillRead mySkill;//宣告程式碼
    public GameObject MySkill;//宣告此程式碼放置物
    // Start is called before the first frame update
    void Start()
    {
        mySkill = MySkill.GetComponent<SkillRead>();//讀取SkillRead程式碼在MySkill物件上的資料
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ReadData();
        }
        
    }

    void ReadData()
    {
        for (int i = 0; i < 10; i++)
        {
            myData[i] = mySkill.newData[i];
        }
    }
    /*void FireBallEvent(int number)//呼叫特效
    {
        Instantiate(FireBallObj[number], FireBall.transform.position, FireBall.transform.rotation);//呼叫NUMBER號特效
    }*/
}
