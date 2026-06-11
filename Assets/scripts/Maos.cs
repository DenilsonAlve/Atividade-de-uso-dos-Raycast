using UnityEngine;

public class Maos : MonoBehaviour
{
    private SpriteRenderer mAtual;
    public Sprite Aumenta;
    public Sprite Diminui;
    public Sprite Dele;
    Raios raios;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAtual = GetComponent<SpriteRenderer>();
       raios = GetComponent<Raios>();
    }

    void Aumentar()
    {
        mAtual.sprite = Aumenta;
    }

    void Deletar()
    {
        mAtual.sprite = Dele;
    }

    void Diminuir()
    {
        mAtual.sprite = Diminui;
    }

    // Update is called once per frame
    void Update()
    {
        if (raios.RaioAu)
        {
            Aumentar();
        }
       
        if (raios.RaioDim)
        {
            Diminuir();
        }

        if (raios.RaioDel)
        {
            Deletar();
        }

    }
}
