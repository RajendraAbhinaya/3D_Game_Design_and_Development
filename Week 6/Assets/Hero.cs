using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    Vector3 maju = Vector3.zero;
    float kecepatan = 3f;
    Transform tubuhChar, hipChar;
    Transform targetLook = null;

    Animator anim;
    [Range(0,1f)] public float distanceToGround;
    public LayerMask layermask;

    void Start(){
        tubuhChar = this.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Chest);
        anim = this.GetComponent<Animator>();
    }

    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if(h!=0 || v!=0) {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            this.transform.rotation = targetRotation;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * v * Time.deltaTime * kecepatan;
            this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * h * Time.deltaTime * kecepatan;
            this.GetComponent<Animator>().SetBool("stat_jalan", true);
        }
        else {
            this.GetComponent<Animator>().SetBool("stat_jalan", false);
        }

        if (Input.GetMouseButtonDown(1)) {
            this.GetComponent<Animator>().SetBool("stat_aim", true);
        }
        if (Input.GetMouseButtonUp(1)) {
            this.GetComponent<Animator>().SetBool("stat_aim", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
            anim.SetBool("isWalk",!anim.GetBool("isWalk"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item") {
            targetLook = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        targetLook = null;
    }
    private void LateUpdate()
    {
        if (targetLook != null)
        {
            float characterY = transform.eulerAngles.y;
            Vector3 itemDistance = targetLook.position - this.transform.position;
            Quaternion lookatRot = Quaternion.LookRotation(itemDistance);
            
            if((characterY - lookatRot.eulerAngles.y)*(characterY - lookatRot.eulerAngles.y) < 4000){
                tubuhChar.LookAt(targetLook.position);
            }
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //LeftFoot
        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
        RaycastHit hit;
        Ray ray = new Ray(anim.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, out hit, distanceToGround + 1f, layermask)) {
            if (hit.transform.tag == "Walkable") {
                Vector3 footPosition = hit.point;
                footPosition.y += distanceToGround;
                anim.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                //anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));
            }
        }

        ray = new Ray(anim.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, out hit, distanceToGround + 1f, layermask)) {
            if (hit.transform.tag == "Walkable") {
                Vector3 footPosition = hit.point;
                footPosition.y += distanceToGround;
                anim.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                //anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));
            }
        }
    }

}
