using System.Threading;
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
    public AudioClip[] clips;
}

public class AudioDialogueManager : ActionMarkupHandler
{
    [Header("Soundss")]
    [SerializeField] private AudioSource dialogueSource;
    [SerializeField] private CharacterSound[] characters;
    [SerializeField] private AudioClip[] defaultSound;

    private AudioClip[] _currentClips;

    [Header("Option")]
    [SerializeField] private float pitchChange = 0.2f;

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
        if((!char.IsWhiteSpace(letra) || !char.IsPunctuation(letra)) && _currentClips?.Length > 0)
        {
            dialogueSource.pitch =1f + Random.Range(-pitchChange, pitchChange);
            dialogueSource.PlayOneShot(_currentClips[Random.Range(0, _currentClips.Length)]);
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
