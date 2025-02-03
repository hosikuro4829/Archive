using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDuel : MonoBehaviour
{

    public GunController gc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDuel()
    {
        gc.duelFlag();
    }

    private void OnTriggerStay(Collider other)
    {
        setDuel();
    }
}
