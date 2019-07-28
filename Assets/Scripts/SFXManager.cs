using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance = null;

    public GameObject boneParticles;
    public GameObject dieParticles;


    void Awake(){
    if(instance == null) {
        instance = this;
    }
}

    public void ShowBoneParticles(GameObject obj) {
        GameObject particles = Instantiate(boneParticles, obj.transform.position, Quaternion.identity);
        GameObject tape = GameObject.Find("Tape");
        particles.transform.SetParent(tape.transform);
    }

    public void ShowDieParticles(GameObject obj) {
        GameObject particles = Instantiate(dieParticles, obj.transform.position, Quaternion.identity);
        GameObject tape = GameObject.Find("Tape");
        particles.transform.SetParent(tape.transform);
    }
}
