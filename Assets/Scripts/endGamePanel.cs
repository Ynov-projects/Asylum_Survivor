using UnityEngine;
using UnityEngine.SceneManagement;

public class endGamePanel : MonoBehaviour
{
    public void onRetryClick()
    {
        gameObject.SetActive(false);
        GameManager.Instance.replay();
    }

    public void onQuitClick()
    {
        Application.Quit();
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
