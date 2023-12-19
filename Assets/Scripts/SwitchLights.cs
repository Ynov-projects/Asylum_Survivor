using System.Collections.Generic;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    private List<Light> lights = new List<Light>();

    public bool isLightOn;

    public static SwitchLights Instance;

    private void Awake()
    {
        if(Instance != null) Destroy(gameObject); 
        Instance = this;
    }

    private void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Light");
        foreach(GameObject go in gameObjects) lights.Add(go.GetComponent<Light>());
    }

    public void Switch()
    {
        isLightOn = !isLightOn;
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
