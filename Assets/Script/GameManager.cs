using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject st1;
    //public GameObject st2;
    //public GameObject st3;
    //bool notouch;
    XRGrabInteractable grab;
    public Animator shot1;
    //public Animator shot2;
    //public Animator shot3;
    public int enemyNum;
    int num;
    public GameObject gun;
    public Judge jud;

    InteractionLayerMask original;
    public InteractionLayerMask target;

    public SerialManager serial;

    float set;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyNum = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Duel()
    {
        int rm = 5;

        StartCoroutine(setDifficulty(rm));

        
        
    }

    public void grabFlag()
    {
        //notouch = true;
    }

    public void setEasy()
    {
        set = 3.0f;//1•b‚ð‰½”{‘¬‚·‚é‚©
        num = 1;
        shot1.SetFloat("Speed", set);
    }

    public void setNormal()
    {
        set = 5.0f;
        num= 2;
        shot1.SetFloat("Speed", set);
    }

    public void setHard()
    {
        set = 10.0f;
        num= 3;
        shot1.SetFloat("Speed", set);
    }

    IEnumerator setDifficulty(int rm)
    {
        yield return new WaitForSeconds(rm);

        //notouch = false;

        //start animation 
        shot1.SetTrigger("Shot1");

        yield return new WaitForSeconds(0.3f);


        st1.SetActive(true);
        //serial.set = true;
    }

    public void retry()
    {
        SceneManager.LoadScene("Main");
    }

    
}
