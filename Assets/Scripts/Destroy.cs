using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            GameObject road = GameObject.FindGameObjectWithTag("Road");

            if (road != null)
            {
                Destroy(road);
            }
        }
    }
}
