using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.XR.OpenXR.Features.Interactions.DPadInteraction;

public class Judge : MonoBehaviour
{
    //銃弾が当たったときtrue
    public bool hit = false;
    public GameObject dead1;
    public GameObject boy1;
    public GameObject Lose;
    public GameObject Win;
    public bool shoot_con=false;
    public GameManager gameManager;

    public SerialManager serialManager;

    public GunController gunc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void win()
    {
        //弾が当たった(勝ち)
        //ラグドール処理
        Destroy(boy1);
        dead1.gameObject.SetActive(true);
        Win.SetActive(true);
    }

    public void lose()
    {
        //Arduino&銃が飛ぶanimation
        hit = true;
        Lose.SetActive(true);
        shoot_con = true;

        serialManager.set = true; //servo
        serialManager.onoff = true;//solenoid
        
        
        Debug.Log("lose");

    }

    public void beat()
    {
        
    }
}
