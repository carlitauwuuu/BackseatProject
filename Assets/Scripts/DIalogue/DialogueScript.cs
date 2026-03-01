using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<string> dialogo;
    [SerializeField] private DialogueUI dialogueUI;

    public void Hablar()
    {
        dialogueUI.MostrarDialogo(dialogo);
    }
}


