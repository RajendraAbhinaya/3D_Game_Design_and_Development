using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float speed = 5f;
    Vector3 pusat;
    Transform obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Pusat").transform;
        pusat = new Vector3(obj.position.x, obj.position.y, obj.position.z + 5f);
    }

    // Update is called once per frame
    void Update()
    {
        pusat = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * pusat;
        this.transform.position = obj.position + pusat;
    }
}
