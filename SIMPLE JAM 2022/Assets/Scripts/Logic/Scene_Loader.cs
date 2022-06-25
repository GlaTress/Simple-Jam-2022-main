using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
    void OnEnable()
    {
        Exit_Warning.onTimerZero += ResetScene;
    }

    void OnDisable()
    {
        Exit_Warning.onTimerZero -= ResetScene;
    }


    private void ResetScene()
    {
        StartCoroutine(ResetCoroutine());
    }

    private IEnumerator ResetCoroutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
