using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFadeAnimationController : MonoBehaviour
{
    public string sceneName;
    private Animator fadeAnim;
    void Start () {
        fadeAnim = gameObject.GetComponent<Animator>();
        fadeAnim.Play("FadeIn", 0, 0f);
    }

    public void fade () {
        fadeAnim.Play("FadeOut", 0, 0f);
        Debug.Log("Fade Out");
    }

    public void fadeIn () {
        SceneManager.LoadScene(sceneName);
        fadeAnim.Play("FadeIn", 0, 0f);
        Debug.Log("Fade In");
    }
}
