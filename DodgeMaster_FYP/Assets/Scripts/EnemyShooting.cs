using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform playerTarget;
    public Transform firePoint;
    //public float shootRange = 100f;
    public Color noHitcolor;
    public Color hitcolor;
    public LineRenderer line;
    public GameObject bullet;

    public LayerMask layer;

    private Animator anim;
    private bool isShoot = true;
    private Vector3 dir;
    private Vector3 lockPos;
    private int random;

    public Vector3 playerHitPoint;


    private void OnEnable()
    {
        anim = GetComponent<Animator>();   
    }

    private void Start()
    {
        //Random target select
        random = Random.Range(0, GameManager.inst.playerTarget.Length);

        line.positionCount = 2;
        
        anim.SetBool("Fire", true);
    }

    private void Update()
    {
        transform.LookAt(playerTarget);

        if (GameManager.inst.isEnemyShoot)
        {

           // anim.SetBool("Fire", true);

           RaycastHit hit;

            if (isShoot)
            {
               dir = GameManager.inst.playerTarget[random].position - firePoint.position;
            }
            else
            {
                dir = lockPos;
            }
                
           if (Physics.Raycast(firePoint.position, dir, out hit, Mathf.Infinity,layer.value))
           {
               // Debug.Log("Ray Cast................... : ");
                if (hit.collider.CompareTag("Player"))
                {
                   // Debug.Log("Ray Cast : " + hit.point);
                    line.material.color = hitcolor;
                    line.SetPosition(0, firePoint.position);
                    //line.SetPosition(1, hit.point - new Vector3(0f,0f,10f));
                    line.SetPosition(1, hit.point);

                    playerHitPoint = hit.point;

                    if (isShoot)
                    {
                        Invoke("Shoot", 1f);
                        lockPos = dir;
                        isShoot = false;
                    }
                    
                   // GameManager.inst.isEnemyShoot = false;
                }
           
               
           }
           else
           {
               line.material.color = noHitcolor;
           }
        }
    }
     public void Shoot()
     {
        GameObject gm = GameObject.Instantiate(bullet, firePoint.position, firePoint.rotation);
        gm.GetComponent<Bullet>().playerHit = playerHitPoint;
     }
}
