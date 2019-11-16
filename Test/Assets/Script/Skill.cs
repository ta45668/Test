using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill : Player 
{
    private SkillRead skillReader;//宣告程式碼
    public GameObject Reader;//宣告放此程式碼的物件
    public GameObject PQPlayer;//宣告玩家

    public Image MP;//宣告魔力
    public int AddMyMP;//宣告回魔速度
    static int idle = Animator.StringToHash("Base Layer.Idle");//宣告Idle的動畫名稱,順便轉成變成數字
    static int attack = Animator.StringToHash("Base Layer.Attack1");//宣告攻擊動作
    static int attack2 = Animator.StringToHash("Base Layer.Attack2");//宣告攻擊2動作
    static int chAt = Animator.StringToHash("Base Layer.CHAt");//宣告攻擊3動作
    static int mahou = Animator.StringToHash("Base Layer.Mahou");//宣告大招動作

    float touchPointX = 0.0f;//點擊螢幕的X座標
    float touchPointY = 0.0f;//點擊螢幕的Y座標

    bool unfighting = false;//是否可以攻擊

    public bool clickStart = false;//是否普功
    public bool maxSkillStart = false;//是否釋放一技
    public bool shieldSkillStart = false;//是否釋放二技
    public bool bigSkillStart = false;//是否釋放大技能

    float MaxMP = 100.0f;//宣告最大魔力
    float NowMP = 100.0f;//宣告現在目前魔力

	// Use this for initialization
	void Start () 
    {
        clickStart = false;//是否普功
        maxSkillStart = false;//是否釋放一技
        shieldSkillStart = false;//是否釋放二技
        bigSkillStart = false;//是否釋放大技能
        skillReader = Reader.GetComponent<SkillRead>();//讀取FireMS程式碼在AttackRange物件上的資料
	}
    /*void OnTap(TapGesture gesture)
    {
        //Debug.Log(Input.mousePosition.x);
        //Debug.Log(Input.mousePosition.y);
        if (!unfighting)
        {
            clickStart = true;//可以普功
        }
    }
    void OnCustomGesture(PointCloudGesture gesture)
    {
        if ((!unfighting) && (MP.fillAmount > 0.5f) && (int.Parse(skillReader.newData[4]) >= 1))//如果有加點技能
        {
            if (gesture.RecognizedTemplate.name == "BigSkill")//如果大技能配對成功
            {
                bigSkillStart = true;//可以釋放
            }
        }
        if ((!unfighting) && (MP.fillAmount > 0.15f) && (int.Parse(skillReader.newData[2]) >= 1))
        {
            if (gesture.RecognizedTemplate.name == "MaxFire")
            {
                maxSkillStart = true;//可以釋放
            }
        }
        if ((!unfighting) && (MP.fillAmount > 0.3f) && (int.Parse(skillReader.newData[3]) >= 1))
        {
            if (gesture.RecognizedTemplate.name == "Shield")
            {
                shieldSkillStart = true;
            }
        }
    }*/
	// Update is called once per frame
	void Update () 
    {
        AddMP();
        MP.fillAmount = NowMP / MaxMP;//計算MP
        if (Input.GetMouseButtonDown(0))//如果觸碰螢幕
        {//儲存XY座標
            touchPointX = Input.mousePosition.x;
            touchPointY = Input.mousePosition.y;
            if (touchPointX >= 10 && touchPointX <= 165 && touchPointY >= 0 && touchPointY <= 165)//判斷位置+如果還沒按開始
            {//移動
                unfighting = true;
            }
            else
            {
                unfighting = false;//可以攻擊
            }
        }
        bs = anim.GetCurrentAnimatorStateInfo(0);//記住現在所執行的動畫
        MyClick();//普功
        MyBigSkil();//大絕
        MyMaxSkill();//1技
        MyShieldSkill();//2技
        
	}
    void AddMP()//回魔
    {
        if (NowMP < 100)//沒滿就補
        {
            NowMP = NowMP + (((AddMyMP * 0.1f) + 1.0f) * 0.05f);
        }
        if (NowMP < 0)//如果等於負的
        {
            NowMP = 0;//歸零
        }
    }
    void MyClick()//普功
    {
        if ((clickStart) && (bs.nameHash != attack))//如果可以攻擊
        {
            //PQPlayer.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);//攻擊時轉向
            anim.SetBool("Skill", true);//就放動畫
            clickStart = false;
        }
        else if (bs.nameHash == attack)//如果現在是attack的動畫
        {
            if (!anim.IsInTransition(0))//如果此動畫(attack)正在播放
            {
                anim.SetBool("Skill", false);//就不放動畫
            }
        }
    }
    void MyBigSkil()//大絕
    {
        if ((bigSkillStart) && (bs.nameHash != mahou))
        {
            NowMP = NowMP - 50.0f;//耗魔
            anim.SetBool("BigSkil", true);
            bigSkillStart = false;
        }
        else if (bs.nameHash == mahou)//如果現在是mahou的動畫
        {
            if (!anim.IsInTransition(0))//如果此動畫(mahou)正在播放
            {
                anim.SetBool("BigSkil", false);//就不放動畫
            }
        }
    }
    void MyMaxSkill()//一技
    {
        if ((maxSkillStart) && (bs.nameHash != attack2))
        {
            NowMP = NowMP - 15.0f;//耗魔
            anim.SetBool("MaxSkill", true);
            maxSkillStart = false;
        }
        else if (bs.nameHash == attack2)//如果現在是attack2的動畫
        {
            if (!anim.IsInTransition(0))//如果此動畫(attack2)正在播放
            {
                anim.SetBool("MaxSkill", false);//就不放動畫
            }
        }
    }
    void MyShieldSkill()//二技
    {
        if ((shieldSkillStart) && (bs.nameHash != chAt))
        {
            NowMP = NowMP - 30.0f;//耗魔
            anim.SetBool("ShieldSkill", true);
            shieldSkillStart = false;
        }
        else if (bs.nameHash == chAt)//如果現在是attack2的動畫
        {
            if (!anim.IsInTransition(0))//如果此動畫(attack2)正在播放
            {
                anim.SetBool("ShieldSkill", false);//就不放動畫
            }
        }
    }
}
