using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject cube;
    private GameObject spawned;
    private int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawned = Instantiate(cube, transform.position, transform.rotation);
        spawned.name = "Cube " + i;
        i++;
    }
}
