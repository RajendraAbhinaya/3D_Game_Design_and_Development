using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_levels : MonoBehaviour
{
    public GameObject[] objLevels;
    private GameObject objLastLevels;
    private bool levelAwal = true;
    public GameObject objHero;
    public GameObject[] objObstacle;
    private GameObject preHero;
    private float kecLari = 10f;
    private int gap = 0;
    private int endLevel = 1;

    void Start () {
        objLastLevels = this.gameObject;
        preHero = Instantiate(objHero, this.transform.position, this.transform.rotation) as GameObject;

        for (int a = 0; a <= 15; a++) {
            buat_level();
        }
    }

    void Update(){
        if (preHero.GetComponent<Sc_character>().statMulai == true) {
            //dapatkan semua child dari GameObject place_levels
            foreach (Transform anak in GameObject.Find("Place_Levels").transform) {
                anak.transform.Translate(new Vector3(0, 0, -kecLari) * Time.deltaTime * (1 + Time.time/100) * endLevel);
                Vector3 posAnakLevel = Camera.main.WorldToViewportPoint(anak.transform.position);
                if (posAnakLevel.z < -16f) {
                    Destroy(anak.gameObject);
                    buat_level();
                }
            }
        }
    }

    void buat_level() {
        Vector3 posLevels = objLastLevels.transform.position;
        if (levelAwal == false) {
            posLevels.z += objLastLevels.GetComponent<Renderer>().bounds.size.z + gap;
            gap = 0;
        }
        int randJenisLevel = Random.Range(0, objLevels.Length);
        GameObject preLevels = Instantiate(objLevels[randJenisLevel], posLevels, this.transform.rotation) as GameObject;
        objLastLevels = preLevels.gameObject;
        objLastLevels.transform.parent = this.transform;
        if (levelAwal == false) {
            int rand = Random.Range(0,5);
            if (rand == 0) {
                buat_obstacle_barrier(preLevels);
            }
        }
        levelAwal = false;
        if(randJenisLevel == 3 || randJenisLevel == 4 || randJenisLevel == 5 || randJenisLevel == 6 || randJenisLevel == 12 || randJenisLevel == 13){
            gap = 9;
        }
    }

    void buat_obstacle_barrier(GameObject tempatLevels) {
        int jenisBarrier = Random.Range(0, 8);
        GameObject objObs = Instantiate(objObstacle[jenisBarrier],
        tempatLevels.transform.position, tempatLevels.transform.rotation) as GameObject;
        objObs.transform.parent = tempatLevels.transform;
    }

    public void stop(){
        endLevel = 0;
    }
}
