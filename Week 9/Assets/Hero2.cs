using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2 : MonoBehaviour
{
    float speed = 3f;
    Animator anim;
    float panjangRay = 5f;
    bool allowMove = false;
    Rigidbody rigidBody;
    float jumpTime = 0f;

    private void Start()
    {
        anim = this.transform.Find("char_ethan").GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //perputaran berdasarkan posisi camera
        if (h != 0 || v != 0) {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection,
            Vector3.up);
            this.transform.rotation = targetRotation;

            anim.SetBool("isJalan", true);
        } 
        else {
            anim.SetBool("isJalan", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpTime < Time.time && !anim.GetBool("isSneak")){
            rigidBody.AddForce(transform.forward + new Vector3(0f, 5f, 0f), ForceMode.Impulse);
            jumpTime = Time.time + 1;

        }

        Vector3 posRayDepan = this.transform.localPosition + transform.forward * 0.5f;
        posRayDepan.y += 1f;
        Ray ray = new Ray(posRayDepan, this.transform.up * -panjangRay);
        Debug.DrawRay(posRayDepan, this.transform.up * -panjangRay, Color.red);
        RaycastHit hit;
        bool isRayHit = Physics.Raycast(ray, out hit, panjangRay);
        if (isRayHit) {
            if (hit.collider.tag == "Tanah") {
                allowMove = true;
            } 
            else {
                allowMove = false;
            }
        } 
        else {
            allowMove = false;
        }

        //pergerakkan berdasarkan posisi camera
        if(allowMove){
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.forward,
            Vector3.up) * v * speed * Time.deltaTime;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right,
            Vector3.up) * h * speed * Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "jembatan") {
            anim.SetBool("isSneak", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "jembatan") {
            anim.SetBool("isSneak", false);
        }
    }
}
