using UnityEngine;

public class Move : MonoBehaviour
{
    

    void Update()
    {
        transform.position += new Vector3(80, 0, 0) * Time.deltaTime;
    }

}
