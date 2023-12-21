using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirate : MonoBehaviour
{
    Animator anim;
    GameObject skeleton;
    float comboAtk = 0f;
    float lastAtk = 0;
    bool isAttackingBool = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        skeleton = GameObject.Find("DungeonSkeleton_demo Variant");
    }

    // Update is called once per frame
    void Update()
    {
        if(!anim.GetBool("Hit")){
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            this.transform.Translate(new Vector3(0, 0, v * 2f) * Time.deltaTime * 3f);
            this.transform.Rotate(new Vector3(0, h / 2, 0) * 5f);

            if (v != 0) {
                anim.SetBool("Walk", true);
            } 
            else {
                anim.SetBool("Walk", false);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                anim.SetBool("Jump", true);
            }

            if (Input.GetButtonDown("Fire1")) {
                lastAtk = Time.time;
                comboAtk++;
                comboAtk = Mathf.Clamp(comboAtk, 0, 3);
                this.GetComponent<Animator>().SetFloat("Attack", comboAtk);
            }
            if (Time.time - lastAtk >= 1f) {
                comboAtk = 0;
                this.GetComponent<Animator>().SetFloat("Attack", comboAtk);
            }
        }
    }

    public void reset_lompat() {
        anim.SetBool("Jump", false);
    }

    public void hit(bool isHit) {
        if(isHit && !isAttackingBool){
            anim.SetBool("Hit", true);
        }
        else{
            anim.SetBool("Hit", false);
        }
    }

    void OnTriggerStay(Collider col){
        if(col.gameObject.tag == "Enemy"){
            if(isAttackingBool){
                skeleton.GetComponent<Skeleton>().attacked(true);
                Invoke("resetHit", 0.5f);
            }
        }
    }

    public void resetHit(){
        skeleton.GetComponent<Skeleton>().attacked(false);
    }

    public void isAttacking(){
        isAttackingBool = true;
        Invoke("isNotAttacking", 0.1f);
    }

    public void isNotAttacking(){
        isAttackingBool = false;
    }
}
