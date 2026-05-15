using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    private bool canSpawn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger") && canSpawn)
        {
            canSpawn = false;

            Instantiate(
                roadSection,
                new Vector3(-509, -10, 20),
                Quaternion.Euler(0, 90, 0)
            );

            Invoke(nameof(ResetSpawn), 0.2f);
        }
    }

    void ResetSpawn()
    {
        canSpawn = true;
    }
}