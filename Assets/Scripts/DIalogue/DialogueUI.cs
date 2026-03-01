using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject textboxPanel;
    [SerializeField] private TMP_Text texto;
    [SerializeField] private float tiempoLetras = 0.02f;

    private List<string> dialogos;
    private int iterador = 0;
    private bool escribiendo = false;

    public event Action OnFinish;

    void Update()
    {
        if (textboxPanel.activeSelf &&
           (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            Next();
        }
    }

    public void MostrarDialogo(List<string> nuevosDialogos)
    {
        dialogos = nuevosDialogos;
        iterador = 0;

        textboxPanel.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TextAppear(dialogos[iterador]));
    }

    public void Next()
    {
        if (escribiendo)
        {
            StopAllCoroutines();
            texto.text = dialogos[iterador];
            escribiendo = false;
            return;
        }

        iterador++;

        if (iterador < dialogos.Count)
        {
            StopAllCoroutines();
            StartCoroutine(TextAppear(dialogos[iterador]));
        }
        else
        {
            textboxPanel.SetActive(false);
            OnFinish?.Invoke();
        }
    }

    IEnumerator TextAppear(string frase)
    {
        escribiendo = true;
        texto.text = "";

        foreach (char letra in frase)
        {
            texto.text += letra;
            yield return new WaitForSeconds(tiempoLetras);
        }

        escribiendo = false;
    }
}