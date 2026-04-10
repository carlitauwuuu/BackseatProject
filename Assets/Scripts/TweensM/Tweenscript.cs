using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tweenscript : MonoBehaviour
{

    private Vector3 _originalPos;
    private bool hasFinishedTween = true;

    private void Awake()
    {
        _originalPos = transform.position;
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame && hasFinishedTween)
        {
            hasFinishedTween = false;
            transform.DOMove(new Vector3(5, 5, 0) + _originalPos, 1f)
            .SetEase(Ease.InOutCubic)
            .OnComplete(()=> 
            {
                hasFinishedTween = true;
            });
            
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame) 
        { 
            hasFinishedTween = false;
         transform.DOMove(_originalPos, 1f)
         .SetEase(Ease.InOutCubic)
         .OnComplete(() =>
         {
             hasFinishedTween = true;
         });
        }

    }
}
