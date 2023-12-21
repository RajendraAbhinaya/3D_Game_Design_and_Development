using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_laser : MonoBehaviour
{
    private LineRenderer lr;
    private GameObject hero;
    private Animator anim;
    void Start () {
        lr = this.GetComponent<LineRenderer>();
        hero = GameObject.Find("hero");
        anim = hero.GetComponent<Animator>();
    }

    void Update () {
        lr.SetPosition(0, this.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        } 
        else {
            lr.SetPosition(1, this.transform.forward*5000);
        }

        if(anim.GetBool("stat_aim")){
            lr.SetWidth(0.02f, 0.02f);
        }
        else{
            lr.SetWidth(0f, 0f);
        }
    }

    public void setLaser(bool on){

    }
}
