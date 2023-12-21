using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Camera : MonoBehaviour
{
    GameObject hero;
    float mouseY;
    float distance;
    bool intersect = false;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("Hero");
        this.transform.rotation = hero.transform.rotation;

        Vector3 posCam = hero.transform.localPosition;
        posCam -= this.transform.forward * 5f;
        this.transform.position = posCam;

        Vector3 distanceVector = hero.transform.position - transform.position;
        distance = distanceVector.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        movecam_by_mouse();
        raycast();
    }

    void movecam_by_mouse() {
        mouseY = Input.GetAxis("Mouse Y");
        if(transform.rotation.eulerAngles.x >= 70 && mouseY < 0){
            mouseY = 0;
        }
        else if(transform.rotation.eulerAngles.x <= 5 && mouseY > 0){
            mouseY = 0;
        }
        this.transform.RotateAround(hero.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 4f);
        this.transform.RotateAround(hero.transform.position, Vector3.left, mouseY * 4f);
        transform.LookAt(hero.transform);

        //Debug.Log("Rotasi: " + this.transform.localEulerAngles);
    }

    void movecam_by_keyboard(){
        float speed = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 50;
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            speed = -50;
        }

        this.transform.LookAt(hero.transform);
        this.transform.RotateAround(hero.transform.position, Vector3.up, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (Vector3.Distance(this.transform.position, hero.transform.position) > 1f) {
                this.transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
            }
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (Vector3.Distance(this.transform.position, hero.transform.position) < 5f)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime, Space.Self);
            }
        }
    }

    void raycast() {
        float panjangRay = 300f;
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * panjangRay, Color.red);
        if (Physics.Raycast(ray, out hit, panjangRay))
        {
            if (hit.transform.name == "Tembok")
            {
                this.transform.Translate(Vector3.forward * 0.1f, Space.Self);
            }
            else if((hero.transform.position - transform.position).magnitude < distance && !intersect){
                this.transform.Translate(Vector3.forward * -0.1f, Space.Self);
            }
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.name == "Tembok"){
            intersect = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.name == "Tembok"){
            intersect = false;
        }
    }
}
