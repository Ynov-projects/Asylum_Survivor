using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePanelScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] numbers;

    public void OnAdd(TextMeshProUGUI number)
    {
        onChange(number, true);
    }

    public void OnLess(TextMeshProUGUI number)
    {
        onChange(number, false);
    }

    private void onChange(TextMeshProUGUI number, bool add)
    {
        int oldNumber = Int32.Parse(number.text);
        if (oldNumber == 0) oldNumber = 10;
        oldNumber = Mathf.Abs((oldNumber + (add ? 1 : -1)) % 10);
        number.text = oldNumber.ToString();
    }

    public void OnSubmit()
    {
        if (numbers[0].text + numbers[1].text + numbers[2].text == UIManager.Instance.GetCode().ToString())
        {
            gameObject.SetActive(false);
            GameManager.Instance.Win();
        }
    }

    public void OnQuit()
    {
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}
