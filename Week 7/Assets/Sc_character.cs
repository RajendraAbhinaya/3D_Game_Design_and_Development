using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_character : MonoBehaviour
{
    private int delayMulai = 3;
    public bool statMulai = false;
    public int health;
    public GameObject hitParticle;
    private Animator anim;
    private float lane = 0f;
    private bool isSliding = false;
    private bool isJumping = false;
    Rigidbody rigidbody;

    void Start () {
        anim = this.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();
        Invoke("mulai_main", delayMulai);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.A) && !isSliding){
            anim.SetBool("Sliding", true);
            isSliding = true;
            lane = Mathf.Clamp(lane - 1.2f, -1.2f, 1.2f);
            Invoke("resetSlide", 1f); 
        }
        if(Input.GetKeyDown(KeyCode.D) && !isSliding){
            anim.SetBool("Sliding", true);
            isSliding = true;
            lane = Mathf.Clamp(lane + 1.2f, -1.2f, 1.2f);
            Invoke("resetSlide", 1f); 
        }
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
            rigidbody.AddForce(0f, 7f, 0f, ForceMode.Impulse);
            anim.SetBool("Jumping", true);
            isJumping = true;
            Invoke("resetJump", 0.7f); 
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, lane, 0.1f), transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "obstacle"){
            GameObject particles = Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(particles, 3f);
            anim.SetTrigger("Hit");
            health--;
            if(health == 0){
                anim.SetBool("Dead", true);
                GameObject.Find("Place_Levels").GetComponent<Sc_levels>().stop();
            }
        }
    }

    private void mulai_main() {
        anim.Play("runStart");
        statMulai = true;
    }

    private void resetSlide(){
        anim.SetBool("Sliding", false);
        isSliding = false;
    }

    private void resetJump(){
        anim.SetBool("Jumping", false);
        isJumping = false;
    }
}
