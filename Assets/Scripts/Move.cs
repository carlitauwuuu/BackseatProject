using UnityEngine;

public class Move : MonoBehaviour
{
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(80, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
