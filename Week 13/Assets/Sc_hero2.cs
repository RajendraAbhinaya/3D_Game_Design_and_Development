using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_hero2 : MonoBehaviour
{
    public float movementSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        this.transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * movementSpeed);
        this.transform.Rotate(new Vector3(0, h, 0) * rotateSpeed);
    }
}
