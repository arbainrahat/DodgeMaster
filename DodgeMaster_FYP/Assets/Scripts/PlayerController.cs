using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController : MonoBehaviour
{
    //public bool setTransform;

    public static PlayerController inst;

    public Transform rightHandTarget;
    public Transform rightHandSource;
    public Rig armRigRight;

    public Transform leftHandTarget;
    public Transform leftHandSource;
    public Rig armRigLeft;

    public Transform headTarget;
    public Transform headSource;
    public Rig headRig;

    public Transform spineTarget;
    public Transform spineSource;
    public Rig spineRig;

    public Transform rightFootTarget;
    public Transform rightFootSource;
    public Rig footRigRight;

    public Transform leftFootTarget;
    public Transform leftFootSource;
    public Rig footRigLeft;

    public Transform rightHandAnchor;
    public Transform leftHandAnchor;
    public Transform headAnchor;
    public Transform spineAnchor;
    public Transform rightFootAnchor;
    public Transform leftFootAnchor;

    public Vector3 OffSet;

    private void Awake()
    {
        inst = this;
    }

    private void OnEnable()
    {
        
    }

    //private void Update()
    //{
    //    //if (setTransform)
    //    //{
    //    //    SetRig();
    //    //    setTransform = false;
    //    //}
    //}

    public void SetRig()
    {
        StartCoroutine(SetIK());
        //print("Set_IK");
    }

    IEnumerator SetIK()
    {
        yield return new WaitForSeconds(GameManager.inst.playerStartWalkStopTime);

        GetComponent<Animator>().SetTrigger("Idle");

        GameManager.inst.isEnemyShoot = true;

        yield return new WaitForSeconds(0.2f);

        rightHandAnchor.gameObject.SetActive(true);
        leftHandAnchor.gameObject.SetActive(true);
        headAnchor.gameObject.SetActive(true);
        spineAnchor.gameObject.SetActive(true);
        rightFootAnchor.gameObject.SetActive(true);
        leftFootAnchor.gameObject.SetActive(true);

        rightHandTarget.position = rightHandSource.position;
        rightHandTarget.rotation = rightHandSource.rotation;
        rightHandAnchor.position = rightHandTarget.position + OffSet;
        armRigRight.weight = 1f;

        leftHandTarget.position = leftHandSource.position;
        leftHandTarget.rotation = leftHandSource.rotation;
        leftHandAnchor.position = leftHandTarget.position + OffSet;
        armRigLeft.weight = 1f;

        headTarget.position = headSource.position;
        headTarget.rotation = headSource.rotation;
        headAnchor.position = headTarget.position + OffSet;
        headRig.weight = 1f;

        spineTarget.position = spineSource.position;
        spineTarget.rotation = spineSource.rotation;
        spineAnchor.position = spineTarget.position + OffSet;
        spineRig.weight = 1f;

        rightFootTarget.position = rightFootSource.position;
        rightFootTarget.rotation = rightFootSource.rotation;
        rightFootAnchor.position = rightFootTarget.position + OffSet;
        footRigRight.weight = 1f;

        leftFootTarget.position = leftFootSource.position;
        leftFootTarget.rotation = leftFootSource.rotation;
        leftFootAnchor.position = leftFootTarget.position + OffSet;
        footRigLeft.weight = 1f;
    }

    public void UnSetRig()
    {
       rightHandAnchor.gameObject.SetActive(false);
        leftHandAnchor.gameObject.SetActive(false);
            headAnchor.gameObject.SetActive(false);
           spineAnchor.gameObject.SetActive(false);
       rightFootAnchor.gameObject.SetActive(false);
        leftFootAnchor.gameObject.SetActive(false);

       armRigRight.weight = 0f;
        armRigLeft.weight = 0f;
           headRig.weight = 0f;
          spineRig.weight = 0f;
      footRigRight.weight = 0f;
       footRigLeft.weight = 0f;
    }

}
