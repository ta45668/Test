using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetMyData : MonoBehaviour 
{
    private SkillRead skillReader;//宣告程式碼
    public GameObject Reader;//宣告放此程式碼的物件
    private MyHPRule myHPRule;//宣告程式碼
    public GameObject player;//宣告此程式碼放置物件
    private Skill mySkill;//宣告程式碼
    public GameObject MySkill;//宣告此程式碼放置物

    public GameObject GameOver;//宣告結束介面
    public GameObject FightOne;//宣告戰鬥攝影機
    public Text PlayerMaxHP;//宣告最大玩家的血量
    public Text PlayerNowHP;//宣告現在玩家的血量

    int maxHP = 0;//最大血量
    int addMP = 0;//回魔速度
	// Use this for initialization
	void Start () 
    {
        mySkill = MySkill.GetComponent<Skill>();//讀取Skill程式碼在MySkill物件上的資料
        skillReader = Reader.GetComponent<SkillRead>();//讀取FireMS程式碼在AttackRange物件上的資料
        myHPRule = player.GetComponent<MyHPRule>();//讀取MyHPRule程式碼在player物件上的資料
        FightOne.SetActive(false);
        GameOver.SetActive(false);
        Setmydata();
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
    public void Setmydata()
    {
        addMP = int.Parse(skillReader.newData[8]);
        maxHP = int.Parse(skillReader.newData[0]) * 100;
        mySkill.AddMyMP = addMP;
        myHPRule.MaxHP = maxHP;
        myHPRule.NowHP = maxHP;
        GameOver.SetActive(false);
        player.SetActive(true);
        FightOne.SetActive(true);
    }
}
