using UnityEngine;
using System.Collections;

public class GeradorBolas : MonoBehaviour
{
    public GameObject objetoOriginal;
    public int limiteMaximo = 20;
    public int quantidadeAtual = 0;
    public bool checaCond = true;

    void Start()
    {
        StartCoroutine(GerarObjetos());
    }

    IEnumerator GerarObjetos()
    {
        while (checaCond == true)
        {
            if (quantidadeAtual < limiteMaximo)
            {
                float xAleatorio = Random.Range(-39, -17);
                float zAleatorio = Random.Range(-39, -29);
                float y = 25f;
                Vector3 posicaoFinal = new Vector3(xAleatorio, y, zAleatorio);

                Instantiate(objetoOriginal, posicaoFinal, Quaternion.identity);
                quantidadeAtual++;

                yield return new WaitForSeconds(0.5f);
            }

            else 
            {
                yield return null;
            }
        }
    }
}


