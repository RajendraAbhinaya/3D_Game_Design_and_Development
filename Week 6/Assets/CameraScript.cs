using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float turnSpeed = 4.0f;
    private Transform posHero;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        posHero = GameObject.Find("hero").transform.Find("CameraPoint").transform;
        offset = new Vector3(posHero.localPosition.x + 1f, posHero.localPosition.y, posHero.localPosition.z + 3f);
    }

    // Update is called once per frame
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = posHero.position + offset;
        transform.LookAt(posHero.position);
    }
}
