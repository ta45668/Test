using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterHPRule : Player 
{
    public GameObject Monster;//宣告怪物
    public GameObject MonsterHPBar;//宣告怪物物件
    public Transform Myplayer;//宣告角色物件
    public Image MonsterHP;//宣告怪物的HP
    public float MaxHP;//宣告怪物最大血量
    public float NowHP;//宣告怪物現在血量
    public int KillScore;//殺死此怪物所獲得的分數

    private GameOver gameover;//宣告程式碼
    public GameObject GameOverMenu;//宣告放此程式碼的物件
    private FireMS fireMS;//宣告程式碼
    public GameObject AttackRange;//宣告放此程式碼的物件
    private MyHPRule myHPRule;//宣告程式碼
    public GameObject PQPlayer;//宣告放此程式碼的物件
    private SkillRead skillRead;//宣告程式碼
    public GameObject Reader;//宣告放此程式碼的物件

    int myVampire = 0;//我的吸血
	// Use this for initialization
	void Start () 
    {
        fireMS = AttackRange.GetComponent<FireMS>();//讀取FireMS程式碼在AttackRange物件上的資料
        gameover = GameOverMenu.GetComponent<GameOver>();//讀取GameOver程式碼在GameOverMenu物件上的資料
        myHPRule = PQPlayer.GetComponent<MyHPRule>();//讀取MyHPRule程式碼在PQPlayer物件上的資料
        skillRead = Reader.GetComponent<SkillRead>();//讀取SkillRead程式碼在Reader物件上的資料
        SetmyVampire();
	}
	
	// Update is called once per frame
	void Update () 
    {
        MonsterHPBar.transform.LookAt(Myplayer.position);
        MonsterHP.fillAmount = NowHP / MaxHP;//顯示怪物血量
        if (NowHP <= 0.0f)
        {
            fireMS.InRange = false;
            NowHP = MaxHP;//血量變回來
            gameover.monsterKill++;//死亡數++
            gameover.myScore += KillScore;//分數++
            Monster.SetActive(false);//砲塔消失
        }
	}
    void OnCollisionEnter(Collision other)//當碰到碰撞器時
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "FireballCollider")//跟魔法做碰撞
        {
            NowHP = NowHP - 50.0f;
            if (myHPRule.NowHP < myHPRule.MaxHP)//如果現在血量小於最大血量
            {
                if ((myVampire + myHPRule.NowHP) > myHPRule.MaxHP)//如果吸血過多
                {
                    myHPRule.NowHP = myHPRule.MaxHP;//血會變成最大值
                }
                else
                {
                    myHPRule.NowHP += myVampire;//直接加血
                }
            }
        }
        else if (other.gameObject.name == "Meteor(Clone)")//跟大絕做碰撞
        {
            NowHP -= 5.0f;
            if (myHPRule.NowHP < myHPRule.MaxHP)//如果現在血量小於最大血量
            {
                if ((myVampire + myHPRule.NowHP) > myHPRule.MaxHP)//如果吸血過多
                {
                    myHPRule.NowHP = myHPRule.MaxHP;//血會變成最大值
                }
                else
                {
                    myHPRule.NowHP += myVampire;//直接加血
                }
            }
        }
        else if (other.gameObject.name == "FireboltCollider")
        {
            NowHP -= 10.0f;
            if (myHPRule.NowHP < myHPRule.MaxHP)//如果現在血量小於最大血量
            {
                if ((myVampire + myHPRule.NowHP) > myHPRule.MaxHP)//如果吸血過多
                {
                    myHPRule.NowHP = myHPRule.MaxHP;//血會變成最大值
                }
                else
                {
                    myHPRule.NowHP += myVampire;//直接加血
                }
            }
        }
    }
    /*void OnCollisionStay(Collision other)//在碰種器表面時
    {
    }
    void OnCollisionExit(Collision other)//當離開碰撞器時
    {
    }*/
    void SetmyVampire()
    {
        myVampire = int.Parse(skillRead.newData[7]) * 10;
    }
}
