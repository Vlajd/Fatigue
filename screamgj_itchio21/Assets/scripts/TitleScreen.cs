using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string startSceneName;
    public void PlayGame() {
        SceneManager.LoadScene(startSceneName);
        
    }
}
