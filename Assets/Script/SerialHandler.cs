using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    string portName = "COM4";//�����ɂ�Arduino�̃|�[�g�ԍ����L��
    int baudRate = 115200;

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private bool isNewMessageReceived_ = false;

    public string readline;

    void Awake()
    {
        Open();
    }

    void Update()
    {
        if (isNewMessageReceived_)
        {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
        serialPort_.Open();

        serialPort_.ReadTimeout = 200;

        isRunning_ = true;

        //thread_ = new Thread(Read);
        //thread_.Start();
    }

    private void Close()
    {
        Write("0"); //�I�I�I����̃R�[�h�ł͂��̍s���Ȃ��Ǝ��s�I������LED�������Ȃ��̂Œ��ӁI�I�I
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive)
        {
            thread_.Join();
        }

        if (serialPort_ != null && serialPort_.IsOpen)
        {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    /*private void Read()
    {
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
        {
            try
            {
                message_ = serialPort_.ReadLine();
                isNewMessageReceived_ = true;
            }
            catch (System.Exception e)
            {
                readline = e.Message;
                Debug.LogWarning("1:" + readline);
            }
        }
    }*/

    public void Write(string message)
    {
        try
        {
            serialPort_.Write("2:" + message);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("3:" + e.Message);

        }
    }
}
