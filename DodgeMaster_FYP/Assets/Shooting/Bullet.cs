//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Bullet : MonoBehaviour
//{

//    private Vector3 shootDir;

//    //Direction setup method
//    public void DirectionSetup(Vector3 shootDir)
//    {
//        this.shootDir = shootDir;
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        float moveSpeed = 250f;
//        transform.position += shootDir * moveSpeed * Time.deltaTime;

//        Destroy(gameObject, 2f);
//    }
//}
