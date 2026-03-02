using TMPro;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.InputSystem;

public class InteractuableController : MonoBehaviour
{
    [SerializeField] Camera pCamera;
    [SerializeField] float interactDistance = 5f;
    [SerializeField] TextMeshProUGUI interactText;

    IInteractuable currentTargetInteractuable;
    void Start()
    {
        
    }

    private void Update()
    {
        UpdateCurrentInteractuable();

        CheckForInteraction();

        UpdateInteractuableText();
    }

    void UpdateCurrentInteractuable()
    {
        var ray = pCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        Physics.Raycast(ray, out var hit, interactDistance);

        if(hit.collider != null)
        {
            var interactuable = hit.collider.GetComponent<IInteractuable>();

            if (interactuable != null)
            {
              currentTargetInteractuable = interactuable;
              return;
            }
        }
        else
        {
            currentTargetInteractuable = null;
        }
    }

    void UpdateInteractuableText()
    {
        if(currentTargetInteractuable == null)
        {
            interactText.text = string.Empty;
            return;
        }

        interactText.text = currentTargetInteractuable.InteractuableMessage;
    }

    void CheckForInteraction()
    {
        if(Keyboard.current[Key.E].wasPressedThisFrame && currentTargetInteractuable != null)
        {
            currentTargetInteractuable.Interact();
        }
    }

}
