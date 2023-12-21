using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_minimap : MonoBehaviour
{
    public Transform objHero;
    
    private void Update() {
        Vector3 posHero = objHero.transform.position;
        posHero.y = this.transform.position.y;
        this.transform.position = posHero;
    }
}
