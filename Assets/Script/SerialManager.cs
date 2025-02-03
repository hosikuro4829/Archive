using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialManager : MonoBehaviour
{
    public SerialHandler serialHandler;
    public GameManager gameManager;


    //受信用変数
    public float data;              //受信データのfloat型版変数
    string receive_data;            //受信した生データを入れる変数

    //送信用変数
    public bool onoff;              //オンオフどちらにするかを決定する変数（今回はオンで固定）
    public bool set;
    //bool cansend = true;            //送信するかどうかを判断する変数

    int count = 1;                  //Arduinoの実行回数

    float span = 3.0f;

    void Start()
    {
        //Debug.Log("test");
        //serialHandler.Write("4");
       // InvokeRepeating("Send", 1, span);
        //serialHandler.OnDataReceived += OnDataReceived;
    }

    //データを受信したら
    /*void OnDataReceived(string message)
    {
        receive_data = (message);           //受信データをreceive_dataに入れる
        data = float.Parse(receive_data);   //float型に変換してdataに入れる
        Debug.Log("受信データ: " + data);
        if(data == 0)
        {
            onoff = false;
        }
    }*/

    private void Update()
    {
        

        if (onoff)
        {
            usendmsg();     //オン用メソッド呼び出し
        }
        else
        {
            //dsendmsg();     //オフ用メソッド呼び出し
        }

        if (set)
        {
            Send();
            Debug.Log("ok");
        }
    }

    //オン用メソッド
    void usendmsg()
    {
        if (count!=0)            
        {
            serialHandler.Write("0");   //Arduinoに0を送信
            Debug.Log("0");
            count--;
            //cansend = false;            //オフになるまで送信不可に設定
        }
        
    }

    //オフ用メソッド
    /*void dsendmsg()
    {
        if (cansend == false)           //送信可能かチェック
        {
            serialHandler.Write("0");   //Arduinoに0を送信
            Debug.Log("0を送信");
            cansend = true;             //オフになるまで送信不可に設定
        }
    }*/

    void Send()
    {
        
        int rot = (int)gameManager.gun.transform.localEulerAngles.y;
        Debug.Log(rot);

        if (rot > 0 && rot <6)
        {
            serialHandler.Write("1");
            Debug.Log("1");
        }
        else if (rot >= 6 && rot < 12)
        {
            serialHandler.Write("2");
            Debug.Log("2");
        }
        else if (rot >= 12 && rot < 18)
        {
            serialHandler.Write("3");
            Debug.Log("3");
        }
        else if (rot >= 18 && rot < 24)
        {
            serialHandler.Write("4");
            Debug.Log("4");
        }
        else if (rot >= 24 && rot < 90)
        {
            serialHandler.Write("5");
            Debug.Log("5");
        }
        else if (rot >= 270 && rot < 336)
        {
            serialHandler.Write("6");
            Debug.Log("6");
        }
        else if (rot >= 336 && rot < 342)
        {
            serialHandler.Write("7");
            Debug.Log("7");
        }
        else if (rot >= 342 && rot < 348)
        {
            serialHandler.Write("8");
            Debug.Log("8");
        }
        else if (rot >= 348 && rot < 354)
        {
            serialHandler.Write("9");
            Debug.Log("9");
        }
        else if (rot >= 354 && rot <= 360)
        {
            serialHandler.Write("1");
            Debug.Log("1");
        }

        //Arduinoにgunのy回転軸を送信
        set = false;
    }
}
