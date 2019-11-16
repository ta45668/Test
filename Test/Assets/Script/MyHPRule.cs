using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MyHPRule : MonoBehaviour 
{
    public Image PlayerHP;//宣告玩家的HP
    public Text PlayerMaxHP;//宣告現在玩家的血量
    public Text PlayerNowHP;//宣告現在玩家的血量
    public GameObject PlayerSubHP;//宣告現在玩家所扣的血量
    public float MaxHP = 10;//宣告玩家最大血量
    public float NowHP = 10;//宣告玩家現在血量
    public GameObject MyFireWall;//宣告我的火牆

    float mytimer = 0.0f;//我的計時器
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1.0f;//遊戲開始
        PlayerSubHP.SetActive(false);//隱藏扣血
        //初始玩家血量顯示
        PlayerNowHP.text = NowHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMaxHP.text = "/" + MaxHP.ToString();
        /*if (checkSubHP)
        {
            PlayerSubHP.SetActive(true);
            Mytimer();
        }*/
        PlayerHP.fillAmount = NowHP / MaxHP;//顯示玩家血條
        PlayerNowHP.text = NowHP.ToString();//顯示玩家血量
        if (NowHP <= 0.0f)//如果血量等於0
        {
            NowHP = 0.0f;//讓血量不會是負的
            Time.timeScale = 0.0f;//整個遊戲暫停
        }
    }
    void OnCollisionEnter(Collision other)//當碰到碰撞器時
    {
        Debug.Log(other.gameObject.name);
        if ((other.gameObject.name == "FireballCollider") && (MyFireWall.active == false))//跟魔法做碰撞
        {
            NowHP = NowHP - 10.0f;
        }
    }
    /*void OnCollisionStay(Collision other)//在碰種器表面時
    {
    }
    void OnCollisionExit(Collision other)//當離開碰撞器時
    {
    }*/
    /*void Mytimer()//顯示扣血
    {
        if (mytimer >= 0.5f)//如果超過
        {
            mytimer = 0;
            PlayerSubHP.SetActive(false);
            checkSubHP = false;
        }
        else
        {
            mytimer += Time.deltaTime;//加一個單位時間
        }
    }*/
    
}
