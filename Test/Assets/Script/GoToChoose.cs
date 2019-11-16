using UnityEngine;
using System.Collections;

public class GoToChoose : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {	
	}
    public void GoBack()//上一頁
    {
        Application.LoadLevel(1);//跳到選角
    }
    public void ReSet()//重新
    {
        Application.LoadLevel(6);//重來
    }
    public void GoToData()//回到紀錄那一層
    {
        Application.LoadLevel(2);
    }
}
