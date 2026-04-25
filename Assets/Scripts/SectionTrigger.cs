using UnityEngine;
using UnityEditor;

public class SectionTrigger : MonoBehaviour
{

    public GameObject roadSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection, new Vector3(-900, 28, -86), Quaternion.identity);
        }
    }

}
