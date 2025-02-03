using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public AudioClip clip;
    public bool soundflag = false;
    float range = 100;
    public Judge jud;
    public bool duel = false;
    public GameObject st;
    public GameObject lose;

    AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
       shotSound = GetComponent<AudioSource>();
        //Sound();
    }

    // Update is called once per frame
    void Update()
    {
        if (jud.hit)
        {
            jud.lose();
            jud.hit = false;
        }

        if (lose.gameObject.activeInHierarchy)
        {
            st.SetActive(false);
        }

    }

    public void duelFlag()
    {
        duel = true;
    }

    public void Shoot()
    {
        if (jud.shoot_con==false&&st.gameObject.activeInHierarchy)
        {
            shotSound.PlayOneShot(clip, 1);

            RaycastHit hit;
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);

            Ray ray = new Ray(transform.position, transform.forward);

            if(Physics.Raycast(ray,out hit, range))
            {
                if (hit.collider.CompareTag("Enemy")&& jud.hit == false)
                {
                    //Destroy(hit.collider.gameObject);
                    jud.win();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Socket"))
        {
            soundflag = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Socket"))
        {
            soundflag = true;
        }
    }

    public void Sound()
    {
        shotSound.PlayOneShot(clip, 1);
        Debug.Log("shot");
    }
}
