using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireMS : MonoBehaviour 
{
    public GameObject GunMuzzle;//宣告炮口
    public Transform Player;//宣告炮口要看誰
    public int MaxEdge;//宣告範圍(最大)
    public int MinEdge;//宣告範圍(最小)
    public bool AddTime;//判斷時間是加的還是減的(+ = true)
    public Transform Fire;//宣告普通攻擊位置Right
    public GameObject FireObj;//宣告普通攻擊特效Right
    public float FireLong;//宣告開火時間

    Quaternion GunRotation;
    public bool InRange = false;//宣告在範圍裡就=TRUE
    bool CheckGunRotation = false;//判斷是否超過範圍    
    float fireTimer = 4.7f;//攻擊計時器
	// Use this for initialization
	void Start () 
    {
        GunRotation = GunMuzzle.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (InRange)
        {
            Firing();
            GunMuzzle.transform.LookAt(Player.position);
        }
        else
        {
            CountGunRotation();
        }
	}
    void OnTriggerEnter(Collider other)//當一進入碰撞器時
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            //Debug.Log("123");
            InRange = true;
        }
    }
    void OnTriggerStay(Collider other)//在碰種器裡面時
    {
    }
    void OnTriggerExit(Collider other)//當一離開碰撞器時
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            if ((GunMuzzle.transform.eulerAngles.y > MaxEdge) || (GunMuzzle.transform.eulerAngles.y < MinEdge))//如果走出邊緣範圍
            { 
                GunMuzzle.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);//位置歸零
            }
            GunMuzzle.transform.rotation = Quaternion.Euler(0.0f, GunMuzzle.transform.eulerAngles.y, 0.0f);
            InRange = false;
        }
    }
    void CountGunRotation()//計算Rotation
    {
        if ((GunMuzzle.transform.eulerAngles.y > MaxEdge) || (GunMuzzle.transform.eulerAngles.y < MinEdge))//如果走到邊緣轉向
        {
            if (AddTime)//如果剛剛是加的
            {
                AddTime = false;//反向
            }
            else
            {
                AddTime = true;
            }
        }
        if (AddTime)//如果要加
        {
            GunMuzzle.transform.Rotate(0.0f, (15.0f * Time.deltaTime), 0.0f);//每個時間加15度
        }
        else
        {
            GunMuzzle.transform.Rotate(0.0f, (-15.0f * Time.deltaTime), 0.0f);
        }
    }
    void Firing()//攻擊
    {
        if (fireTimer >= FireLong)//如果超過
        {
            fireTimer = 0;//歸零
            Instantiate(FireObj, Fire.transform.position, Fire.transform.rotation);//呼叫特效
        }
        else
        {
            fireTimer += Time.deltaTime;//加一個單位時間
        }
    }
}
