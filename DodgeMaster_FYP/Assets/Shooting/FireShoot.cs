using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShoot : MonoBehaviour
{
    public Transform crosshair;  //Get crosshair
    public Camera _cam;

    //Sound Fields
    private AudioSource source;
    public AudioClip clipSound;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        // //when left mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            Firing();
        }
    }

    public void Firing() 
    {
        GameManager.inst.animatorPlayer.SetTrigger("Shoot");

        //Cast ray from main camera at position of crosshair
        Ray ray = _cam.ScreenPointToRay(crosshair.position);
        //Get raycast information
        RaycastHit hit;
        //if ray hit something
        if (Physics.Raycast(ray, out hit))
        {
            //Play Fire Sound
            source.clip = clipSound;
            source.Play();

            Debug.Log("Name : "+ hit.transform.name);
            //Update score at hit target
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Hit");
                hit.transform.GetComponent<Animator>().SetBool("Idle", false);
                hit.transform.GetComponent<Animator>().SetBool("Death", true);
            }
        }
    }
    
}
