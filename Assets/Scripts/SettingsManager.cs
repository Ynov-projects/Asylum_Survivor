using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI languageText;
    [SerializeField] private TextMeshProUGUI returnText;

    [SerializeField] private TextMeshProUGUI[] languages;
    [SerializeField] private TextMeshProUGUI[] difficulties;
    [SerializeField] private TextMeshProUGUI[] otherTexts;

    [SerializeField] private GameObject pnlMain;
    [SerializeField] private GameObject pnlOptions;

    void Start()
    {
        if (!PlayerPrefs.HasKey("difficulty")) PlayerPrefs.SetInt("difficulty", 1);
        if (!PlayerPrefs.HasKey("language")) PlayerPrefs.SetInt("language", 2);
        getTraductions();
        setButtons();
    }

    private void getTraductions()
    {
        languageText.text = Traductions.getTraduction("language");
        returnText.text = Traductions.getTraduction("return");

        foreach (TextMeshProUGUI language in languages) language.text = Traductions.getTraduction(language.transform.parent.name);
        foreach (TextMeshProUGUI difficulty in difficulties) difficulty.text = Traductions.getTraduction(difficulty.transform.parent.name);
        foreach (TextMeshProUGUI otherText in otherTexts) otherText.text = Traductions.getTraduction(otherText.transform.parent.name);
    }

    private void resetButtons(TextMeshProUGUI[] texts)
    {
        foreach (TextMeshProUGUI text in texts) text.color = new Color(0.36f, 0, 0, 1);
    }

    private void setButtons()
    {
        foreach (TextMeshProUGUI text in languages) if (int.Parse(text.transform.parent.name.Split("language")[1]) == PlayerPrefs.GetInt("language")) text.color = new Color(1f, 1, 1, 1);
        foreach (TextMeshProUGUI text in difficulties) if (int.Parse(text.transform.parent.name.Split("difficulty")[1])== PlayerPrefs.GetInt("difficulty")) text.color = new Color(1f, 1, 1, 1);
    }

    #region "onclick"
    public void OnLanguageClick(TextMeshProUGUI text)
    {
        resetButtons(languages);
        text.color = Color.white;
        PlayerPrefs.SetInt("language", int.Parse(text.transform.parent.name.Split("language")[1]));
        getTraductions();
    }

    public void OnDifficultyClick(TextMeshProUGUI text)
    {
        resetButtons(difficulties);
        text.color = Color.white;
        PlayerPrefs.SetInt("difficulty", int.Parse(text.transform.parent.name.Split("difficulty")[1]));
    }

    public void switchOptions(bool main)
    {
        pnlMain.SetActive(main);
        pnlOptions.SetActive(!main);
    }

    public void play()
    {
        SceneManager.LoadScene("AsylumGame");
    }

    public void quit()
    {
        Application.Quit();
    }
#endregion
}
