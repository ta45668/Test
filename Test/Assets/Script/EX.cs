using UnityEngine;
using System.Collections;

public class EX : Player 
{
    static int idle = Animator.StringToHash("MyBase.Idle");//宣告Idle的動畫名稱,順便轉成變成數字(0)
    static int down = Animator.StringToHash("MyBase.MYA");//宣告down的動畫名稱,順便轉成變成數字(1)
    static int headspring = Animator.StringToHash("MyBase.HeadSpring");//宣告headspring的動畫名稱,順便轉成變成數字(2)
    static int jab = Animator.StringToHash("MyBase.M_CMN_LJAB");//宣告jab的動畫名稱,順便轉成變成數字(3)    
    static int risingP = Animator.StringToHash("MyBase.M_RISING_P");//宣告risingP的動畫名稱,順便轉成變成數字(4)
    static int rhikick = Animator.StringToHash("MyBase.RHiKick");//宣告rhikick的動畫名稱,順便轉成變成數字(5)
    static int mawak = Animator.StringToHash("MyBase.CH01_AS_MAWAK");//宣告mawak的動畫名稱,順便轉成變成數字(6)

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        bs = anim.GetCurrentAnimatorStateInfo(0);//記住現在所執行的動畫
        if (bs.nameHash == idle)//如果現在是idle的動畫and animationNumber = 0
        {
            if (!anim.IsInTransition(0))//如果此動畫(idle)正在播放
            {
                anim.SetBool("SkLoop1", true);//可以放動畫1
            }
        }
        else if (bs.nameHash == mawak)//如果現在是mawak的動畫and animationNumber = 6
        {
            if (!anim.IsInTransition(0))//如果此動畫(mawak)正在播放
            {
                anim.SetBool("SkLoop1", false);//就不放動畫1
            }
        }
	}
}
