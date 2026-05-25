using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

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

}

[System.Serializable]
public class AudioYarn
{
    public string nick;
    public EventReference eventReference;
}
