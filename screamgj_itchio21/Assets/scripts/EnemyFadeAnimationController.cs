using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFadeAnimationController : MonoBehaviour
{
    public string sceneName;
    private Animator fadeAnim;
    void Start () {
        fadeAnim = gameObject.GetComponent<Animator>();
    }

    public void enemyFade () {
        fadeAnim.Play("EnemySFXFadeOut", 0, 0f);
    }
}
