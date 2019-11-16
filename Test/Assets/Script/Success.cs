using UnityEngine;
using System.Collections;

public class Success : MonoBehaviour 
{
    public GameObject SuccessButton;//宣告存成功的按鈕
    public GameObject MyAdd;//宣告我的按鈕
	// Use this for initialization
	void Start () 
    {
        SuccessButton.SetActive(false);
        MyAdd.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    public void Save()
    {
        SuccessButton.SetActive(true);
        MyAdd.SetActive(false);
    }
    public void SaveSuccess()//當存成功後按下去時
    {
        SuccessButton.SetActive(false);//此按鈕消失
        MyAdd.SetActive(true);
    }
}
