using UnityEngine;
using Yarn.Unity;
public class ObjectSpawner : MonoBehaviour
{
 public GameObject[] prefabs;
    public Transform[] spawnPoints;

    public DialogueRunner dialogueRunner;

    void Awake()
    {
        dialogueRunner = FindFirstObjectByType<DialogueRunner>();

       dialogueRunner.AddCommandHandler<int, int>("spawn_object", SpawnObject);
    }

    public void SpawnObject(int prefabIndex, int spawnIndex)
    {
        if (prefabIndex < prefabs.Length && spawnIndex < spawnPoints.Length)
        {
            Instantiate(prefabs[prefabIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }
}