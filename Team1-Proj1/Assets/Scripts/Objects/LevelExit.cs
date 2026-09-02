//Erik Robertson
//9/2/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public void LoadNextScene()
    {
        Time.timeScale = 1.0f;
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }
}
