using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    int life = 3;

    public Text TextLife;
    Rigidbody2D rb;
    Animator anim;

    private Animator dogAnimator;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dogAnimator = GetComponent<Animator>();
        TextLife.text = life.ToString();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bone")) {
            SFXManager.instance.ShowBoneParticles(other.gameObject);
            AudioManager.instance.PlaySoundBonePickup(other.gameObject);
            Destroy(other.gameObject);
            LevelManager.instance.IncrementBoneCount();
        }
        else if (other.gameObject.CompareTag("Gift")) {
            StopMusicAndTape();
            AudioManager.instance.PlaySoundLevelComplete(gameObject);
            Destroy(gameObject);
            LevelManager.instance.ShowLevelCompletePanel();
        }
        else if (other.gameObject.CompareTag("Life")) {
            if (life < 3) {
                life++;
                TextLife.text = life.ToString();
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
            HurtPlayer();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Forbidden")) {
            KillPlayer();
        }
    }

    void StopMusicAndTape() {
        Camera.main.GetComponentInChildren<AudioSource>().mute = true;
        LevelManager.instance.SetTapeSpeed(0);  
    }

    void HurtPlayer() {
        life--;
        TextLife.text = life.ToString();
        if (life == 0){
            KillPlayer();
        }
    }

    void KillPlayer() {
        Destroy(gameObject);
        StopMusicAndTape();
        AudioManager.instance.PlaySoundFail(gameObject);
        LevelManager.instance.ShowGameOverPanel();
    }
}
