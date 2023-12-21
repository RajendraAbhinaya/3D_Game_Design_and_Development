using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float turnSpeed = 4.0f;
    private Transform posHero;
    private Vector3 offset;

    void Start()
    {
        posHero = GameObject.Find("hero").transform;
        offset = new Vector3(posHero.position.x, posHero.position.y + 3f,
        posHero.position.z + 2f);
    }
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = posHero.position + offset;
        transform.LookAt(posHero.Find("objsrot").transform.position);
    }
}
