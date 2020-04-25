using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematics : MonoBehaviour
{
    void Start() { StartCoroutine(LoadNextScene()); }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(47f);
        SceneManager.LoadScene("Gameplay");
    }
}
