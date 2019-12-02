using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public float waitTime = 3f;
    public string nextScene = "Main";
    

    void Start()
    {
        StartCoroutine (Next());
    }

    IEnumerator Next (){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextScene);
    }
}
