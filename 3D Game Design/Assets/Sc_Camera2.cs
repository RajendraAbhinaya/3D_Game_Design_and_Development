using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Camera2 : MonoBehaviour
{
    GameObject hero;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("hero");
        //offset = new Vector3(0, 0, 0);
        this.transform.rotation = hero.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        offset = hero.transform.forward * -2f;
        offset += hero.transform.up * 1f;
        this.transform.LookAt(hero.transform);
        this.transform.position = hero.transform.position + offset;
    }
}
