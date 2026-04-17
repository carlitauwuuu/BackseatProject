using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManagerAudio : MonoBehaviour
{
    [SerializeField] EventReference MusicData;
    [SerializeField] EventReference SFXData;
    void Start()
    {
        AudioManager.Instance.PlayMusic(MusicData);
        AudioManager.Instance.StopMusic();
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            AudioManager.Instance.PlaySFX(SFXData);
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            AudioManager.Instance.StopMusic();
        }
    }
}
