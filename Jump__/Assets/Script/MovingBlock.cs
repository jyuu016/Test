using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;

    public Transform TargetPoint;

    public float MoveSpeed = 5f;
    public  bool isMovingTowardEnd = true;

    private void Update()
    {
        Target();

       
    }

    private void Target()
    {
       
    }

    private void OnGUI()
    {
        Vector3 vStart = StartPoint.position;
        Vector3 vEnd = EndPoint.position;
        Vector3 vPos = transform.position;
       
        //Vector3 targerPosition = isMovingTowardEnd ? vEnd : vStart;


        //if (isMovingTowardEnd)
        //{
        //    TargetPoint = EndPoint;
        //    Debug.Log("Move End!");
        //}
        //else
        //{
        //    TargetPoint = StartPoint;
        //    Debug.Log("Move Start!");
        //}

        Vector3 vTargetPos = TargetPoint.position;

        

        //if (vPos == vTargetPos)
        //{
        //    isMovingTowardEnd = !isMovingTowardEnd;
        //}
        // ㅁ자아요!
        if (isMovingTowardEnd)
        {
            transform.position = Vector3.Lerp(vPos, vTargetPos, Time.deltaTime);
        }

        float fDist = Vector3.Distance(vPos, vTargetPos);

        if (fDist < 0.1)
        {
            Debug.Log("Change Target!");
            if (TargetPoint.gameObject.name == EndPoint.gameObject.name)
                TargetPoint = StartPoint;
            else if (TargetPoint.gameObject.name == StartPoint.gameObject.name)//네 네!!
                TargetPoint = EndPoint;
            //isMovingTowardEnd = false;
        }

        Vector3 vScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Box(new Rect(vScreenPos.x, Screen.height - vScreenPos.y, 150, 20), string.Format("move {1}, dist:{0}",fDist, isMovingTowardEnd));
    }
}
