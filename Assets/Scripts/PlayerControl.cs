using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    private Animator dogAnimator;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dogAnimator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bone")) {
            SFXManager.instance.ShowBoneParticles(other.gameObject);
            AudioManager.instance.PlaySoundCoinPickup(other.gameObject);
            Destroy(other.gameObject);
            LevelManager.instance.IncrementBoneCount();
        }
        if (other.gameObject.CompareTag("Gift")) {
            StopMusicAndTape();
            AudioManager.instance.PlaySoundLevelComplete(gameObject);
            Destroy(gameObject);
            LevelManager.instance.ShowLevelCompletePanel();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
            anim.SetTrigger("death");
            KillPlayer();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Forbidden")) {
            anim.SetTrigger("death");
            KillPlayer();
        }
    }

    void StopMusicAndTape() {
      Camera.main.GetComponentInChildren<AudioSource>().mute = true;
        LevelManager.instance.SetTapeSpeed(0);  
    }
    void KillPlayer() {
        StopMusicAndTape();
        AudioManager.instance.PlaySoundFail(gameObject);
        LevelManager.instance.ShowGameOverPanel();
    }
}
