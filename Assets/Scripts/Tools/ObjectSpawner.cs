using UnityEngine;
using Yarn.Unity;
public class ObjectSpawner : MonoBehaviour
{
    public int NumSelector = 5
    [SerializeField] private GameObject[] spawnables;
    private DialogueRunner dRunner;
     

    void Awake()
    {
        dRunner = GetComponent<DialogueRunner>();
        dRunner.AddCommandHandler("spawn_object", SpawnObject);
    }



    public void SpawnObject(int  count)
    {
         if (spawnables != null)
        {
            Instantiate(spawneable[], transform.position, Quaternion.identity);
           
        }
    }
}
