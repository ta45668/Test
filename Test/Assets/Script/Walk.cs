using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Walk : Player 
{
    public float walkTreeNumber = 0.0f;//宣告WalkTree的參數
    public float walkTreeNumber2 = 0.0f;//宣告WalkTree的參數
    public GameObject player;//宣告玩家物件

    bool isDown;
    bool isLeft;
    bool isUp;
    bool isRight;
    bool gamestart;//遊戲開始

    void Start()
    {
    }
    void Update()
    {
        if (isDown)//如果向後走
        {
            if (walkTreeNumber2 < 0.71f)//太小
            {
                walkTreeNumber2 += Time.deltaTime;//加回來
            }
            else if(walkTreeNumber2 > 0.71f)//太大
            {
                walkTreeNumber2 -= Time.deltaTime;//減掉
            }
            if (walkTreeNumber > -0.71f)//太大
            {
                walkTreeNumber -= Time.deltaTime;//減掉
            }
            else if(walkTreeNumber < -0.71f)//太小
            {
                walkTreeNumber += Time.deltaTime;//加回來
            }
            PlayerTrun(-0.87f, 0.5f, -0.5f, 0.87f);
            isDown = false;
        }
        else
        {
        }


        if (isUp)//如果向前
        {
            PlayerMiddle();//把重心移到中間
            PlayerTrun(-1.0f, 0.0f, 0.0f, 1.0f);
            isUp = false;
        }
        else
        {
        }

        if (isLeft)//如果左轉
        {
            PlayerRunning(-0.96f, 0.26f);
            isLeft = false;
        }
        else
        {
        }

        if (isRight)//如果右轉
        {
            PlayerRunning(-0.26f, 0.96f);
            isRight = false;
        }
        else
        {
        }
        anim.SetFloat("WalkTree", walkTreeNumber);//負的
        anim.SetFloat("WalkTree2", walkTreeNumber2);//正的
    }

    public void MoveStart()
    {
        anim.SetBool("Walk", true);//初始Walk的狀態
        gamestart = true;
    }

    public void Move(Vector2 move)
    {
    }

    public void MoveSpeed(Vector2 move)
    {
    }

    public void MoveEnd()
    {
        anim.SetBool("Walk", false);//初始Walk的狀態
        isUp = false;
        isLeft = false;
        isRight = false;
        isDown = false;
        gamestart = false;
    }

    public void TouchStart()
    {
    }

    public void TouchUp()
    {
        anim.SetBool("Walk", false);//初始Walk的狀態
        isUp = false;
        isLeft = false;
        isRight = false;
        isDown = false;
        gamestart = false;
    }

    public void DownRight()
    {
    }

    public void DownDown()
    {
    }

    public void DownLeft()
    {
    }

    public void DownUp()
    {
    }

    public void Right()
    {
        isRight = true;
    }

    public void Down()
    {
        isDown = true;
    }

    public void Left()
    {
        isLeft = true;
    }

    public void Up()
    {
        isUp = true;
    }


    IEnumerator ClearText(Text textToCLead)
    {
        yield return new WaitForSeconds(0.3f);
        textToCLead.text = "";
    }
    void PlayerMiddle()//置中
    {
        if (walkTreeNumber < 0.0f)//太小
        {
            walkTreeNumber += Time.deltaTime;//加回來
        }
        if (walkTreeNumber2 > 0.0f)//太大
        {
            walkTreeNumber2 -= Time.deltaTime;//減掉
        }
    }
    void PlayerRunning(float number1, float number2)//走路中
    {
        if (walkTreeNumber < number1)//太小
        {
            walkTreeNumber += Time.deltaTime;//加回來
        }
        else if (walkTreeNumber > number1)//太大
        {
            walkTreeNumber -= Time.deltaTime;//減掉
        }
        if (walkTreeNumber2 < number2)//太小
        {
            walkTreeNumber2 += Time.deltaTime;//加回來
        }
        else if (walkTreeNumber2 > number2)//太大
        {
            walkTreeNumber2 -= Time.deltaTime;//減掉
        }
    }
    void PlayerTrun(float number1, float number2, float number3, float number4)//轉彎forward(是否向前)
    {
        if (isLeft)
        {
            if (walkTreeNumber < number1)//太小
            {
                walkTreeNumber += Time.deltaTime;//加回來
            }
            else if (walkTreeNumber > number1)//太大
            {
                walkTreeNumber -= Time.deltaTime;//減掉
            }
            if (walkTreeNumber2 < number2)//太小
            {
                walkTreeNumber2 += Time.deltaTime;//加回來
            }
            else if (walkTreeNumber2 > number2)//太大
            {
                walkTreeNumber2 -= Time.deltaTime;//減掉
            }
        }
        else if (isRight)
        {
            if (walkTreeNumber < number3)//太小
            {
                walkTreeNumber += Time.deltaTime;//加回來
            }
            else if (walkTreeNumber > number3)//太大
            {
                walkTreeNumber -= Time.deltaTime;//減掉
            }
            if (walkTreeNumber2 < number4)//太小
            {
                walkTreeNumber2 += Time.deltaTime;//加回來
            }
            else if (walkTreeNumber2 > number4)//太大
            {
                walkTreeNumber2 -= Time.deltaTime;//減掉
            }
        }
    }
}
