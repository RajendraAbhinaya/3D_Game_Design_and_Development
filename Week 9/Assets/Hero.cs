using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] Transform[] pointList;
    float heroSpeed = 3f;
    int checkPoint = 0;
    int nextPoint = 0;
    int prevPoint = 0;
    void Start()
    {
        Vector3 posAwal = this.transform.position;
        posAwal.x = pointList[checkPoint].position.x;
        posAwal.z = pointList[checkPoint].position.z;
        this.transform.position = posAwal;
    }
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        if (v > 0) {
            nextPoint = checkPoint + 1;
            nextPoint = Mathf.Clamp(nextPoint, 0, pointList.Length-1);
            gerak_hero(nextPoint,v);
        } 
        else if (v < 0) {
            prevPoint = checkPoint;
            prevPoint = Mathf.Clamp(prevPoint, 0, pointList.Length);
            gerak_hero(prevPoint, v);
        }
    }

    private void gerak_hero(int targetPoint, float v) {
        Vector3 posTarget = this.transform.position;
        posTarget.x = pointList[targetPoint].position.x;
        posTarget.z = pointList[targetPoint].position.z;

        this.transform.position = Vector3.MoveTowards(this.transform.position, posTarget, Mathf.Abs(v) * heroSpeed * Time.deltaTime);
        Vector3 currentPosHero = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        Vector3 pointPosTarget = new Vector3(pointList[targetPoint].position.x, 0, pointList[targetPoint].position.z);
        float jarakPoint = Vector3.Distance(currentPosHero, pointPosTarget);

        Vector3 direction = pointPosTarget - currentPosHero;
        transform.rotation = Quaternion.LookRotation(direction);

        if (jarakPoint < 0.3f) {
            if (v > 0 && checkPoint != nextPoint) {
                checkPoint += 1;
            } 
            else if (v < 0) {
                checkPoint -= 1;
            }
        }
    }


}
