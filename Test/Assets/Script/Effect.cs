using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour 
{
    public Transform FireBall;//宣告普通攻擊位置Right
    public GameObject[] FireBallObj;//宣告普通攻擊特效Right
    public Transform FireBig;//宣告普通攻擊位置Right
    public GameObject FireBigObj;//宣告普通攻擊特效Right

    public GameObject FireWall;//宣告火牆
    float mytimer = 0.0f;//我的計時器
    bool FireWallStart = false;//宣告火牆是否開始
	// Use this for initialization
	void Start () 
    {
        FireWall.SetActive(false);
        FireWallStart = false;//宣告火牆是否開始
        mytimer = 0.0f;//我的計時器
	}
    void FireBallEvent(int number)//呼叫特效
    {
        Instantiate(FireBallObj[number], FireBall.transform.position, FireBall.transform.rotation);//呼叫NUMBER號特效
    }
    void FireBigEvent()//呼叫特效
    {
        Instantiate(FireBigObj, FireBig.transform.position, FireBig.transform.rotation);//呼叫NUMBER號特效
    }
    void FireEvent()//呼叫特效
    {
        FireWallStart = true;//開始
        FireWall.SetActive(true);//顯示
    }
	// Update is called once per frame
	void Update () 
    {
        if (FireWallStart)//如果開始
        {
            Mytimer();
        }
	}
    void Mytimer()
    {
        if (mytimer >= 10.0f)//如果超過
        {
            FireWallStart = false;//不開始
            mytimer = 0;//歸零
            FireWall.SetActive(false);//不顯示
        }
        else
        {
            mytimer += Time.deltaTime;//加一個單位時間
        }
    }
}
