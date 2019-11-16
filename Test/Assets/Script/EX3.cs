using UnityEngine;
using System.Collections;

public class EX3 : MonoBehaviour 
{
    public GameObject MyArms;//武器
    public GameObject rArms;//武器擺放位置
	// Use this for initialization
	void Start () 
    {
        rArms = GameObject.Find("MyArms");
	}
	
	// Update is called once per frame
	void Update () 
    {
        PickUp();
	}
    void PickUp()
    {
        MyArms.gameObject.transform.position = rArms.transform.position;
        MyArms.gameObject.transform.rotation = rArms.transform.rotation;
        MyArms.gameObject.transform.parent = rArms.transform;
    }
}
