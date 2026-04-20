using System.Threading;
using FMODUnity;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Yarn;
using Yarn.Markup;
using Yarn.Unity;


[System.Serializable]
public class CharacterSound
{
    public string charaterName;
    public EventReference clips;
}

public class AudioDialogueManager : ActionMarkupHandler
{
    [Header("Soundss")]
    [SerializeField] private CharacterSound[] characters;
    [SerializeField] private EventReference defaultSound;

    private EventReference _currentClips;

    public override void OnPrepareForLine(MarkupParseResult line, TMP_Text text)
    {
        if(characters == null)
        {
            _currentClips = defaultSound;
            Debug.LogWarning("NO TIENES CHARACTERS ASSIGNADOS EN AUDIO DIALOGUE");
        }
            if (line.TryGetAttributeWithName("character", out var attribute))
        {
            string characterName = attribute.Properties["name"].StringValue;
            foreach (var chara in characters)
            {
                if (chara.charaterName == characterName)
                {
                    _currentClips = chara.clips;
                    break;
                }
            }
        }

    }
    public override YarnTask OnCharacterWillAppear(int currentCharacterIndex, MarkupParseResult line, CancellationToken cancellationToken)
    {
        char letra = line.Text [currentCharacterIndex];
        if(!char.IsWhiteSpace(letra) || !char.IsPunctuation(letra))
        {
            RuntimeManager.PlayOneShot(_currentClips,transform.position);
        }
        return YarnTask.CompletedTask;
    }

    public override void OnLineDisplayBegin(MarkupParseResult line, TMP_Text text)
    {}

    public override void OnLineDisplayComplete()
    {}

    public override void OnLineWillDismiss()
    {}

   
}
