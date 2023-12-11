using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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