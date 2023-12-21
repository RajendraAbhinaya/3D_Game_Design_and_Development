using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] Transform[] tujuan;
    [SerializeField] GameObject player;
    [SerializeField] float viewRange;
    int size, destination;
    bool isAttacking = false;
    bool inRange = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        size = tujuan.Length;
        destination = Random.Range(0, size);
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = 1f;
        if(isAttacking){
            movementSpeed = 0f;
        }
        Vector3 distanceFromPlayer = player.transform.position - transform.position;
        Quaternion direction = Quaternion.LookRotation(distanceFromPlayer);
        if(distanceFromPlayer.magnitude <= viewRange){
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 2f * Time.deltaTime * movementSpeed);
            this.transform.rotation = direction;
            anim.SetBool("Walk", true);
        }
        else{
            patrol();
        }
    }

    void patrol(){
        Vector3 distance = tujuan[destination].transform.position - transform.position;
        if(distance.magnitude > 1f){
            this.transform.position = Vector3.MoveTowards(this.transform.position, tujuan[destination].transform.position, 2f * Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(distance);
            anim.SetBool("Walk", true);
        }
        else{
            destination = Random.Range(0, size);
            anim.SetBool("Walk", false);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.name == "Lady Pirate"){
            anim.SetBool("Attack", true);
            isAttacking = true;
            inRange = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.name == "Lady Pirate"){
            anim.SetBool("Attack", false);
            inRange = false;
            //isAttacking = false;
        }
    }

    public void attack(){
        if(!inRange){
            isAttacking = false;
        }
    }

    public void hitPlayer(){
        if(inRange && !anim.GetBool("Hit")){
            player.GetComponent<pirate>().hit(true);
            Invoke("resetHit", 0.1f);
        }
    }

    public void resetHit(){
        player.GetComponent<pirate>().hit(false);
    }

    public void attacked(bool isHit){
        if(isHit){
            anim.SetBool("Hit", true);
        }
        else{
            anim.SetBool("Hit", false);
        }
    }
}
