using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiTween : MonoBehaviour
{
   private CanvasGroup _canvasGroup;

   private float _initialAlpha;

   private bool hasFinishedTween = true;

   [SerializeField] private float animationTime = 1f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _initialAlpha = _canvasGroup.alpha;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame && hasFinishedTween)
        {
            hasFinishedTween = false;
            _canvasGroup.DOFade(1f, animationTime)
                .SetEase(Ease.OutSine)
                .OnComplete(() =>
                {
                    hasFinishedTween = true;
                    _canvasGroup.blocksRaycasts = true;
                    _canvasGroup.interactable = true;
                });
                
        }

        else if (Keyboard.current.eKey.wasPressedThisFrame && hasFinishedTween)
        {
            hasFinishedTween = false;
            _canvasGroup.DOFade(_initialAlpha, animationTime)
                .SetEase(Ease.OutSine)
                .OnComplete(() =>
                {
                    hasFinishedTween = true;
                    _canvasGroup.blocksRaycasts = false;
                    _canvasGroup.interactable = false;
                });
        }
    }
}


