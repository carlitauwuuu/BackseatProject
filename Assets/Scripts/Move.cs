using UnityEngine;

public class Move : MonoBehaviour
{
    public int _speed = 70;
    public float segmentLenght = 427.1597f;

    Transform _transform;
    Vector3 initialPosition;
    float respawnPoint = 279.5597f;
    float respawnOffset = -574.7f;
    Vector3 respawnPosition;

    void Start()
    {
        _transform = transform;
        initialPosition = _transform.position;
        respawnPosition = new Vector3(respawnOffset, initialPosition.y, initialPosition.z);
    }

    void Update()
    {   
        if (_transform.position.x >= respawnPoint) _transform.position = respawnPosition;

        _transform.Translate(0,0,_speed * Time.deltaTime);
    }
}