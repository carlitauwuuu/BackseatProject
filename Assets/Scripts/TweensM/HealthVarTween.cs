using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthVarTween : MonoBehaviour
{
    [SerializeField] Image barraBack;
    [SerializeField] Image barraFront;
    [SerializeField] TextMeshProUGUI textoVida;
    [SerializeField] int maxVida = 100;
    [SerializeField] float timeTweens = 0.5f;
    [SerializeField] float delayTime = 0.5f;

    private int _vidaActual;

    void Awake()
    {
        _vidaActual = maxVida;
        textoVida.text = _vidaActual.ToString();
    }

    public void Damage(int damage)
    {
        int vidaNueva = Mathf.Max(0, _vidaActual  - damage);
        float targetFill = (float)vidaNueva / maxVida;

        barraFront.DOFillAmount(targetFill, timeTweens)
                .SetEase(Ease.OutCubic);
        barraBack.DOFillAmount(targetFill, timeTweens)
                .SetDelay(delayTime).SetEase(Ease.OutCubic);

        DOTween.To(() => _vidaActual, x =>
        {
        _vidaActual = x;
        textoVida.text = _vidaActual.ToString();
        }, vidaNueva, timeTweens).SetEase(Ease.OutCubic);
           
        
    }

    void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Damage(25);
        }


    }

}
