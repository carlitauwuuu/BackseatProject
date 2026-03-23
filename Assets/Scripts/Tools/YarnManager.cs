using UnityEngine;
using Yarn.Unity;
public class YarnManager : MonoBehaviour
{
    //lectura valores
    [YarnFunction("leer_moneda")]
    public static int LeerMoneda()
{
    return GameManager.Instance.monedas;
}

[YarnFunction("esta_muerto")]
public static bool LeerMuerte()
    {
        return GameManager.Instance.estaVivo;
    }
    //escritura ejecucion codigo

    [YarnFunction("random_jump")]
    public static string JumpRandom(params string [] nodes)
    {
        return nodes[Random.Range(0, nodes.Length)];
    }

    [YarnCommand("dar_moneda")]
    public static void DarMoneda(int cantidad)
    {
        GameManager.Instance.monedas +=cantidad;
    }
    

    [YarnCommand("quitar_moneda")]
    public static void Quitarmoneda(int cantidad)
    {
        GameManager.Instance.monedas -=cantidad;
    }

    [YarnCommand("quitar_vida")]
    public static void QuitarVida()
    {
        GameManager.Instance.estaVivo = false;
    }
}
