using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using Yarn.Unity;
 
public class YarnSoundFunctions : MonoBehaviour
{
    [SerializeField] private List<AudioYarn> audioYarns = new();
    private Dictionary<string, EventReference> dictionaryDataAudio;
 
    void Awake()
    {
        dictionaryDataAudio = new Dictionary<string, EventReference>(System.StringComparer.OrdinalIgnoreCase);
        foreach(var e in audioYarns)
        {
            if (!e.eventReference.IsNull && !string.IsNullOrEmpty(e.nick))
            {
                dictionaryDataAudio[e.nick] = e.eventReference;
            }
        }
    }
 
    void Start()
    {
        var dialogueRunner = Object.FindFirstObjectByType<DialogueRunner>();
        if (dialogueRunner != null)
        {
            dialogueRunner.AddCommandHandler<string, float, float, float>("Play_SFX", CommandPlaySFX);
            dialogueRunner.AddCommandHandler<string, float, float, float, float, string>("Play_SFX_With_Number", CommandPlaySFXWithNumber);
            dialogueRunner.AddCommandHandler<string, float, float, float, string, string>("Play_SFX_With_String", CommandPlaySFXWithString);
            dialogueRunner.AddCommandHandler<string>("Play_Music", CommandPlayMusic);
            dialogueRunner.AddCommandHandler("Stop_Music", CommandStopMusic);
        }
    }  
 
    private void CommandPlaySFX(string nick, float x, float y, float z)
    {
        if(!TryGetAudioData(nick, out var eventRef)) return;
        AudioManager.Instance.PlaySFX(eventRef, new Vector3(x, y, z));
    }
    private void CommandPlaySFXWithNumber(string nick, float x, float y, float z, float parameterValue, string parameterName)
    {
        if (!TryGetAudioData(nick, out var eventRef)) return;
        AudioManager.Instance.PlaySFX(eventRef, new Vector3(x, y, z), parameterValue, parameterName);
    }
    private void CommandPlaySFXWithString(string nick, float x, float y, float z, string parameterValue, string parameterName)
    {
        if (!TryGetAudioData(nick, out var eventRef)) return;
        AudioManager.Instance.PlaySFX(eventRef, new Vector3(x, y, z), parameterValue, parameterName);
    }
    private void CommandPlayMusic(string nick)
    {
        if (!TryGetAudioData(nick, out var eventRef)) return;
        AudioManager.Instance.PlayMusic(eventRef);
    }
    private void CommandStopMusic()
    {
        AudioManager.Instance.StopMusic();
    }
 
    private bool TryGetAudioData(string nick, out EventReference eventRef)
    {
        if(dictionaryDataAudio.TryGetValue(nick, out eventRef))
        {
            return true;
        }
        Debug.LogWarning($"Audio with nick {nick} not found.");
        return false;
    }
 
}
 
[System.Serializable]
public class AudioYarn
{
    public string nick;
    public EventReference eventReference;
}