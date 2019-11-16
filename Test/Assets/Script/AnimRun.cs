using UnityEngine;
using System.Collections;

public class AnimRun : Player 
{
	// Use this for initialization
	void Start () 
    {	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.Log(ETCInput.GetAxis("Horizontal"));//左右
        //Debug.Log(ETCInput.GetAxis("Vertical"));//前後
        bs = anim.GetCurrentAnimatorStateInfo(0);//記住現在所執行的動畫
	}
}
