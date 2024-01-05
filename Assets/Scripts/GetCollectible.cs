using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollectible : MonoBehaviour
{
    public static GetCollectible Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<ItemScript>() != null)
                {
                    hit.transform.gameObject.GetComponent<ItemScript>().OnClick();
                }
            }
        }
    }
}
