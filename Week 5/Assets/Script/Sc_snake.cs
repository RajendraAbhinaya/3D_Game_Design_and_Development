using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_snake : MonoBehaviour
{
    float turnSpeed = 150f;
    float speed = 3f;
    [SerializeField] GameObject objBuntut;
    private GameObject tail;

    void Start(){
        tail = this.gameObject;
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        float h = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up * h * turnSpeed * Time.deltaTime);
    }
    
    public void tambah_panjang_snake() 
    {
        Debug.Log("Snake Makan Items");
        GameObject tempTail = Instantiate(objBuntut, tail.transform.position, Quaternion.identity);
        tempTail.GetComponent<Buntut>().setTarget(tail);
        tail = tempTail;
    }
}
