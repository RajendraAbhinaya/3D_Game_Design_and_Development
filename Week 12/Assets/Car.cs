using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float motorForce = 500f;
    private float steerForce = 20f;
    private float powerBrake = 100000f;

    public WheelCollider roda1;
    public WheelCollider roda2;
    public WheelCollider roda3;
    public WheelCollider roda4;
    
    void Update () {
        float v = Input.GetAxis("Vertical") * motorForce;
        roda1.motorTorque = v;
        roda2.motorTorque = v;
        roda3.motorTorque = v;
        roda4.motorTorque = v;

        float h = Input.GetAxis("Horizontal") * steerForce;
        roda1.steerAngle = h;
        roda2.steerAngle = h;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            roda1.brakeTorque = 0;
            roda2.brakeTorque = 0;
            roda3.brakeTorque = 0;
            roda4.brakeTorque = 0;
        }
    }
}
