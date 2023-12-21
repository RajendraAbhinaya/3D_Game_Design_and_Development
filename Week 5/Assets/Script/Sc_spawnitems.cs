using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_spawnitems : MonoBehaviour
{
    [SerializeField] GameObject objItems;
    int banyak = 30;
    void Start()
    {
        for (int a = 0; a < banyak; a++) {
            Vector3 pos = this.transform.position;
            pos.x = Random.Range(-10f, 10f);
            pos.z = Random.Range(-10f, 10f);
            Instantiate(objItems, pos, Quaternion.identity);
        }
    }
}
