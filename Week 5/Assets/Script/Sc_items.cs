using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_items : MonoBehaviour
{
    GameObject snake;
    private void Awake()
    {
        snake = GameObject.Find("snakes");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("kena: " + other.gameObject.name);
        snake.SendMessage("tambah_panjang_snake");
        Destroy(this.gameObject);
    }

}
