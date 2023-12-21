using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 10f);
    }

    private void OnTriggerEnter(Collider col) {
        Debug.Log("Box collide dengan " + col.gameObject.name);
        Destroy(col.gameObject);
    }
}
