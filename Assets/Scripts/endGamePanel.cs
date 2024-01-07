using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGamePanel : MonoBehaviour
{
    public void onRetryClick()
    {
        gameObject.SetActive(false);
        GetCollectible.Instance.enabled = true;
        CameraFollow.Instance.enabled = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
}
