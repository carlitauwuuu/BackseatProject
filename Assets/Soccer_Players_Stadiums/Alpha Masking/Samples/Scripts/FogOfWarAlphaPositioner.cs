using UnityEngine;

public class FogOfWarAlphaPositioner : MonoBehaviour
{
    public Transform dungeonCharacter;

    void Update()
    {
        transform.position = new Vector3(dungeonCharacter.position.x, dungeonCharacter.position.y, transform.position.z);
    }
}
