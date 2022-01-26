using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMovement : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    private float unClampXPos;
    private float unClampYPos;

    public float minX = 1f;
    public float maxX = 1f;
    public float minY = 1f;
    public float maxY = 1f;

    public Transform targetToMove;

    private void Start()
    {
        // Store current position of anchor for clamp w.r.t current position
        unClampXPos = transform.position.x;
        unClampYPos = transform.position.y;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 pos = GetMouseAsWorldPoint() + mOffset;
        float posX = Mathf.Clamp(pos.x, unClampXPos - minX, unClampXPos + maxX);
        float posY = Mathf.Clamp(pos.y, unClampYPos - minY, unClampYPos + maxY);
        transform.position = new Vector3(posX, posY, pos.z);
        //transform.position = GetMouseAsWorldPoint() + mOffset;

        //Set target to move on mouse drag
        targetToMove.position = new Vector3(transform.position.x,transform.position.y,targetToMove.position.z);
    }
}
