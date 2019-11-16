using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
    private GameOver gameover;//宣告程式碼
    private MyHPRule myHPRule;//宣告程式碼
    public GameObject player;//宣告此程式碼放置物件
    public GameObject[] Monster;//宣告所有的怪物

    public Image PlayerGameover;//宣告玩家死亡的菜單
    public GameObject PlayerGameoverMenu;//顯示死亡菜單
    public Text ScoreNumber;//宣告分數的TEXT

    public int myScore = 0;//宣告分數
    public int monsterKill = 0;//宣告死了幾個怪物
	// Use this for initialization
	void Start () 
    {
        gameover = GetComponent<GameOver>();//讀取GameOver程式碼上的資料
        myHPRule = player.GetComponent<MyHPRule>();//讀取MyHPRule程式碼在player物件上的資料
        PlayerGameover.fillAmount = 0.0f;//設定圖片等於零
        PlayerGameoverMenu.SetActive(false);//不顯示菜單
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (monsterKill >= 3)//如果地圖上沒有怪了
        {
            player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            for (int i = 0; i < 3; i++)
            {
                Monster[i].SetActive(true);
            }
            monsterKill = 0;
        }
        Debug.Log(myScore);
        if (myHPRule.NowHP <= 0)
        {
            ScoreNumber.text = myScore.ToString();
            PlayerGameoverMenu.SetActive(true);//顯示菜單
            ShowGameOverMenu();
        }
        
	}
    void ShowGameOverMenu()//顯示結束菜單
    {
        if (PlayerGameover.fillAmount <= 1.0f)//慢慢秀出來
        {
            PlayerGameover.fillAmount += 0.05f;
        }
    }
}
