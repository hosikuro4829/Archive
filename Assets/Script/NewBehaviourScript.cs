using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Judge jud;
    AudioSource  m_AudioSource;
    public AudioClip clip;
    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(jud.Lose.activeInHierarchy && flag)
        {
            m_AudioSource.PlayOneShot(clip);
            Debug.Log("bang");
            flag = false;
        }
    }
}
