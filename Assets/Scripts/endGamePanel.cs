using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGamePanel : MonoBehaviour
{
    public void onRetryClick()
    {
        gameObject.SetActive(false);
        MouseInteraction.Instance.enabled = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
}
