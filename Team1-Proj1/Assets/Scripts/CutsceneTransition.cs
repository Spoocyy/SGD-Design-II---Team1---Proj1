using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition : MonoBehaviour
{
    [SerializeField] float cutsceneDuration = 25f;
    [SerializeField] string nextScene = "Level 1";

    private void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(cutsceneDuration);

        SceneManager.LoadScene(nextScene);
    }
}
