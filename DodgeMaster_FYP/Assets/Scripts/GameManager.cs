using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    //Data Fields

    public float playerStartWalkStopTime = 2f;
    public float playerDodgeTime = 10f;
    public float fpsEnableAfter = 2f;

    [HideInInspector] public bool isEnemyShoot = false;
    [Tooltip("Player body targets for enemy shoot")]
    public Transform[] playerTarget;

    //FPS Reference
    public Animator animatorPlayer;
    public GameObject fpsCam;
    public GameObject mainCam;
    public GameObject virtualCam;
    public GameObject fpsUI;
    public FireShoot fireShoot;

    public GameObject[] enemy;

    [HideInInspector] public bool isFps = false;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        PlayerController.inst.SetRig();
    }

    public void SetFPS()
    {
        StartCoroutine(Fps());
    }

    public void StopFps()
    {
        animatorPlayer.SetTrigger("Death");
        StopAllCoroutines();
        PlayerController.inst.UnSetRig();
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<LineRenderer>().enabled = false;
            enemy[i].GetComponent<Animator>().SetBool("Fire", false);
            enemy[i].GetComponent<Animator>().SetBool("Idle", true);
        }
    }

    IEnumerator Fps()
    {
       
        //print("Set Fps -===============");
        yield return new WaitForSeconds(fpsEnableAfter);

        PlayerController.inst.UnSetRig();

        animatorPlayer.applyRootMotion = false;
        mainCam.SetActive(false);
        virtualCam.SetActive(false);
        fpsCam.SetActive(true);
        fpsUI.SetActive(true);
        fireShoot.enabled = true;

        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<LineRenderer>().enabled = false;
            enemy[i].GetComponent<Animator>().SetBool("Fire", false);
            enemy[i].GetComponent<Animator>().SetBool("Idle", true);
        }
    }
}
