using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_gerak1 : MonoBehaviour
{
    [SerializeField] Transform tujuan1;
    [SerializeField] Transform tujuan2;
    float kecepatan = 3f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = tujuan1.position;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //gerakan1();
        //gerakan2();
        //gerakan3();
        //gerakan4();
        gerakan5();
    }

    void gerakan1(){
        if (Vector3.Distance(this.transform.position,tujuan1.transform.position)>0.1f) {
            Vector3 pos = this.transform.position;
            pos.z += kecepatan * Time.deltaTime;
            this.transform.position = pos;
        }
    }

    void gerakan2(){
        this.transform.position = Vector3.Lerp(this.transform.position, tujuan1.transform.position, 2f * Time.deltaTime);
    }

    void gerakan3(){
        this.transform.position = Vector3.MoveTowards(this.transform.position, tujuan1.transform.position, 2f * Time.deltaTime);
    }

    void gerakan4() {
        Vector3 jarak = tujuan1.position - this.transform.position;
        jarak = jarak.normalized * kecepatan;
        rb.AddForce(jarak);
    }

    void gerakan5() {
        //this.transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
        this.transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
        this.transform.Rotate(Vector3.up * 2f);
    }
}
