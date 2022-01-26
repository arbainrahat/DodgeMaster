using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 playerHit;

    private bool goAway = false;

    private void OnEnable()
    {

        StartCoroutine(BulletSpeedControl());
    }

    private void Start()
    {
        Destroy(gameObject, 20f);
    }

    private void FixedUpdate()
    {
        if (transform.position == playerHit && !goAway)
        {
           // Debug.Log("..........................Bullet........................");
            goAway = true;
        }

        if (!goAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerHit, Time.fixedDeltaTime * speed);
        }
        else
        {
            //  transform.position -= new Vector3(0f, 0f, Time.fixedDeltaTime * speed);
            transform.position += transform.forward * Time.fixedDeltaTime* speed;
        }  
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit");

            //When Bullet Hit with Player
            GameManager.inst.StopFps();

            // Destroy(gameObject);
        }
    }

   IEnumerator BulletSpeedControl()
    {
        yield return new WaitForSeconds(0.3f);
        speed = 0;
        yield return new WaitForSeconds(GameManager.inst.playerDodgeTime);
        speed = 5f;

        //Set Fps after dodge

        if (!GameManager.inst.isFps)
        {
            GameManager.inst.SetFPS();
            GameManager.inst.isFps = true;
        }
    }
    
}
