using UnityEngine;

public class InteractuableObject : MonoBehaviour, IInteractuable

{
    public string InteractuableMessage
    {
        get { return interactMessage; }
    }

    [SerializeField] string interactMessage;

    public void Interact()
    {
        Destroy(gameObject);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
