using UnityEngine;

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
}
