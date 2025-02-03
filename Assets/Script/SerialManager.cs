using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialManager : MonoBehaviour
{
    public SerialHandler serialHandler;
    public GameManager gameManager;


    //��M�p�ϐ�
    public float data;              //��M�f�[�^��float�^�ŕϐ�
    string receive_data;            //��M�������f�[�^������ϐ�

    //���M�p�ϐ�
    public bool onoff;              //�I���I�t�ǂ���ɂ��邩�����肷��ϐ��i����̓I���ŌŒ�j
    public bool set;
    //bool cansend = true;            //���M���邩�ǂ����𔻒f����ϐ�

    int count = 1;                  //Arduino�̎��s��

    float span = 3.0f;

    void Start()
    {
        //Debug.Log("test");
        //serialHandler.Write("4");
       // InvokeRepeating("Send", 1, span);
        //serialHandler.OnDataReceived += OnDataReceived;
    }

    //�f�[�^����M������
    /*void OnDataReceived(string message)
    {
        receive_data = (message);           //��M�f�[�^��receive_data�ɓ����
        data = float.Parse(receive_data);   //float�^�ɕϊ�����data�ɓ����
        Debug.Log("��M�f�[�^: " + data);
        if(data == 0)
        {
            onoff = false;
        }
    }*/

    private void Update()
    {
        

        if (onoff)
        {
            usendmsg();     //�I���p���\�b�h�Ăяo��
        }
        else
        {
            //dsendmsg();     //�I�t�p���\�b�h�Ăяo��
        }

        if (set)
        {
            Send();
            Debug.Log("ok");
        }
    }

    //�I���p���\�b�h
    void usendmsg()
    {
        if (count!=0)            
        {
            serialHandler.Write("0");   //Arduino��0�𑗐M
            Debug.Log("0");
            count--;
            //cansend = false;            //�I�t�ɂȂ�܂ő��M�s�ɐݒ�
        }
        
    }

    //�I�t�p���\�b�h
    /*void dsendmsg()
    {
        if (cansend == false)           //���M�\���`�F�b�N
        {
            serialHandler.Write("0");   //Arduino��0�𑗐M
            Debug.Log("0�𑗐M");
            cansend = true;             //�I�t�ɂȂ�܂ő��M�s�ɐݒ�
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

        //Arduino��gun��y��]���𑗐M
        set = false;
    }
}
