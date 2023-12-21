using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.AddComponent<Rigidbody>();
        velocity =  new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
    }

    private void OnTriggerEnter(Collider col) {
        Debug.Log(gameObject.name + " collide dengan " + col.gameObject.name);
    }

}
