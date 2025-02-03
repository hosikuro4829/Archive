using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : MonoBehaviour
{

    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void easy()
    {
        animator.SetTrigger("Easy");
    }

    void normal()
    {
        animator.SetTrigger("Normal");
    }

    void hard()
    {
        animator.SetTrigger("Hard");
    }

    public void checkDif(int sel) { 
    
    if (sel == 0)
        {
            easy();
        }
    else if (sel == 1)
        {
            normal();
        }
    else if (sel == 2)
        {
            hard();
        }
    }
}
