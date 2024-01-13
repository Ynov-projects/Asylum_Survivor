using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    private bool someoneHere;

    [SerializeField] private GameObject codePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") someoneHere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") someoneHere = false;
    }

    private void Update()
    {
        if (someoneHere)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Cursor.visible = true;
                codePanel.SetActive(true);
            }
        }
    }
}
