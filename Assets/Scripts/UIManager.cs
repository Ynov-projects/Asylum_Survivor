using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameObject panel;

    public void closePanel()
    {
        panel.SetActive(false);
    }
}
