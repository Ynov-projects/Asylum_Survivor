using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    void Update()
    {
        music.pitch = Mathf.Lerp(music.pitch, 0.8f + (1 - PlayerMentalHealth.Instance.getStress()) * 2, Time.deltaTime);
    }
}
