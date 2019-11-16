using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillAddRule : MonoBehaviour 
{
    private SkillRead skillReader;//宣告程式碼
    public GameObject Reader;//宣告放此程式碼的物件
    public Text MyPoint;//宣告顯示剩餘點數
    public Text[] SkillAdd = new Text[4];//宣告技能加點情況
    public Text BoolAdd;//宣告血量加點情況
    public Text VampireAdd;//宣告吸血加點情況
    public Text MPAdd;//宣告回魔加點情況
    public GameObject[] No = new GameObject[3];//宣告是否可以加點

    int MyHP = 0;//宣告血量變數
    int VampireHP= 0;//吸血變數
    int AddMP = 0;//宣告回魔變數
    int i = 0;//宣告變數
    int[] skill = new int[4];//宣告技能變數
    int myPoint = 0;//宣告點數變數
    Color setFirst = new Color(0.0f, 255.0f, 255.0f);
    Color setRed = new Color(255.0f, 0.0f, 0.0f);
	// Use this for initialization
	void Start () 
    {
        for (i = 0; i < 3; i++)
        {
            No[i].SetActive(true);
        }
        skillReader = Reader.GetComponent<SkillRead>();//讀取FireMS程式碼在AttackRange物件上的資料
	}
	
	// Update is called once per frame
	void Update () 
    {
        myPoint = int.Parse(skillReader.newData[5]);//讀取點數資料
        MyHP = int.Parse(skillReader.newData[0]);//讀取血量資料
        MyPoint.text = myPoint.ToString();//顯示所剩點數

        if (MyHP > 10)//如果點滿的話(0)
        {
            skillReader.newData[0] = "15";
        }
        Max(BoolAdd, MyHP, 1);//MyHP顯示
        Max(VampireAdd, VampireHP, 0);//吸血
        VampireHP = int.Parse(skillReader.newData[7]);//讀取吸血資料
        Max(MPAdd, AddMP, 0);//回魔
        AddMP = int.Parse(skillReader.newData[8]);//讀取回魔資料

        for (i = 0; i < 4; i++)
        {
            ShowSkillNumber(i);
        }
	}
    public void AddBool()//加血
    {
        if (myPoint > 0)//如果點數大於0
        {
            if (MyHP < 11)//如果沒有超過血量上限(1500)
            {
                myPoint--;//減少1單位點數
                MyHP++;//增加1單位血量
                skillReader.newData[5] = myPoint.ToString();//儲存修改後點數資料
                skillReader.newData[0] = MyHP.ToString();//儲存修改後血量資料
            }
        }
    }
    public void AddVampire()//吸血
    {
        if (myPoint > 0)//如果點數大於0
        {
            if (VampireHP < 10)//如果沒有超過吸血上限(100)
            {
                myPoint--;//減少1單位點數
                VampireHP++;//增加1單位血量
                skillReader.newData[5] = myPoint.ToString();//儲存修改後點數資料
                skillReader.newData[7] = VampireHP.ToString();//儲存修改後吸血資料
            }
        }
    }
    public void AddMyMP()//回魔
    {
        if (myPoint > 0)//如果點數大於0
        {
            if (AddMP < 10)//如果沒有超過回魔上限(10)
            {
                myPoint--;//減少1單位點數
                AddMP++;//增加1單位血量
                skillReader.newData[5] = myPoint.ToString();//儲存修改後點數資料
                skillReader.newData[8] = AddMP.ToString();//儲存修改後吸血資料
            }
        }
    }
    public void AddSkill01()//加技能一
    {
        if (myPoint > 0)//如果點數大於0
        {
            CountSkill(0);//計算
        }
    }
    public void AddSkill02()//加技能二
    {
        if ((myPoint > 0) && (No[0].active == false))//如果點數大於0加上解放
        {
            CountSkill(1);//計算
        }
    }
    public void AddSkill03()//加技能三
    {
        if ((myPoint > 0) && (No[1].active == false))//如果點數大於0加上解放
        {
            CountSkill(2);//計算
        }
    }
    public void AddSkill04()//加技能4
    {
        if ((myPoint > 0) && (No[2].active == false))//如果點數大於0加上解放
        {
            CountSkill(3);//計算
        }
    }
    void ShowSkillNumber(int number)//顯示
    {
        skill[number] = int.Parse(skillReader.newData[number + 1]);//讀取技能資料
        Max(SkillAdd[number], skill[number], 0);
        if ((skill[number] >= 5) && (number < 3))//如果此技能大於五或技能小於3
        {
            No[number].SetActive(false);//技能解放
        }
    }
    void CountSkill(int number)//計算技能點
    {
        if (skill[number] < 10)//如果沒有超過加點上限
        {
            myPoint--;//減少1單位點數
            skill[number]++;//增加1級技能
            skillReader.newData[5] = myPoint.ToString();//儲存修改後點數資料
            skillReader.newData[number + 1] = skill[number].ToString();//儲存修改後技能一資料
        }
    }
    public void ReSetAll()//重新加點
    {
        skillReader.newData[0] = "1";//初始血量
        skillReader.newData[1] = "1";//初始技能一(普功)
        for (i = 2; i < 5; i++)
        {
            skillReader.newData[i] = "0";//初始技能點
        }
        skillReader.newData[7] = "0";//初始吸血
        skillReader.newData[8] = "0";//初始回魔
        for (i = 0; i < 3; i++)
        {
            No[i].SetActive(true);
        }
        skillReader.newData[5] = skillReader.newData[6];//還原現有技能點
    }
    public void GoToPlay()//開始遊戲
    {
        Application.LoadLevel(6);//跳到法師技能場景
    }
    void Max(Text myText, int textNumber, int discrepancy)//文字顯示
    {
        if (textNumber >= 10)//如果點滿的話(3)
        {
            myText.text = "MAX";//換內文
            myText.color = setRed;//換顏色
            myText.fontSize = 15;//改字體大小
        }
        else
        {
            myText.text = (textNumber - discrepancy).ToString();//顯示所加點數
            myText.color = setFirst;//還原
            myText.fontSize = 30;//改字體大小
        }
    }
}
