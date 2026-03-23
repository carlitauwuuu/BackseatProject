using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   public DialogueRunner dialogueRunner;
   [HideInInspector] public bool estaVivo;
   [HideInInspector] public int monedas;
   
   void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;


    }
    void Start()
    {
         dialogueRunner.StartDialogue("Start");
    }
}
