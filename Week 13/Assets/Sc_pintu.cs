using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_pintu : MonoBehaviour
{
    HingeJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = this.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = this.transform.localEulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle;

        if (joint.useMotor == true) {
            if (Mathf.Abs(angle) >= 80) {
                Invoke("delay_tutup_otomatis", 1f);
            }
        } 
        else {
            if (Mathf.Abs(angle) <= 2f) {
                Vector3 rot = this.transform.localEulerAngles;
                rot.y = 0;
                this.transform.localEulerAngles = rot;
                joint.useMotor = false;
                joint.useSpring = false;
            }
        }
    }

    void delay_tutup_otomatis() {
        joint.useMotor = false;
        joint.useSpring = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "hero") {
            joint.useMotor = true;
            joint.useSpring = false;
        }
    }
}
