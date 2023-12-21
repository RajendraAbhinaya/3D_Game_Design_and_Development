using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buntut : MonoBehaviour
{
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, 2f * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
    }

    public void setTarget(GameObject target){
        this.target = target;
        transform.position = target.transform.position - target.transform.forward;
    }
}
