using UnityEngine;

public class Raios : MonoBehaviour
{
    public bool RaioDim = true;
    public bool RaioAu = false;
    public bool RaioDel = false;
    public GameObject maosinhas;
    public float distanciaDoRaio = 100f;
    public GeradorBolas bolas;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AtirarRaycast();

        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            RaioDim = true;
            RaioAu = false;
            RaioDel = false;
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            RaioDim = false;
            RaioAu = false;
            RaioDel = true;  
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaioDim = false;
            RaioAu = true;
            RaioDel = false;
        }

    }

    void AtirarRaycast()
    {
        if (RaioDim == true)
        {
            float xAleatorio = Random.Range(39, 7);
            float zAleatorio = Random.Range(39, 29);

            Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

   
            if (Physics.Raycast(raio, out hit, distanciaDoRaio))
            {
                if (hit.collider.CompareTag("alvo"))
                {
                    GameObject objetoAtingido = hit.collider.gameObject;
                    objetoAtingido.transform.localScale *= 0.8f;

                    if (objetoAtingido.transform.localScale.x < 0.5)
                    {
                        Destroy(hit.transform.gameObject);
                        bolas.quantidadeAtual --;
                    }
                }
            }
        }
        else if (RaioAu == true) 
        {

            Ray raio = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
            RaycastHit hit;

           
            if (Physics.Raycast(raio, out hit, distanciaDoRaio))
            {
                if (hit.collider.CompareTag("alvo"))
                {
                    GameObject objetoAtingido = hit.collider.gameObject;
                    objetoAtingido.transform.localScale *= 1.2f;

                    if (objetoAtingido.transform.localScale.x > 10) 
                    {
                        Destroy(hit.transform.gameObject);
                        bolas.quantidadeAtual--;
                    }
                }
            }

        }

        else if (RaioDel == true)
        {
            float Xale = Random.Range(0.3f, 1.8f);
            float Zale = Random.Range(0.3f, 1.8f);
            float Yale = Random.Range(0.3f, 1.8f);

            Ray raio = new  (maosinhas.transform.position, transform.forward);
            RaycastHit hit;


            if (Physics.Raycast(raio, out hit, distanciaDoRaio))
            {
                if (hit.collider.CompareTag("alvo"))
                {
                    GameObject objetoAtingido = hit.collider.gameObject;
                    objetoAtingido.transform.localScale = Vector3.Scale(objetoAtingido.transform.localScale, new Vector3(Xale, Yale, Zale)); 

                    if (objetoAtingido.transform.localScale.x > 12 || objetoAtingido.transform.localScale.y > 12 || objetoAtingido.transform.localScale.z > 12)
                    {
                        Destroy(hit.transform.gameObject);
                        bolas.quantidadeAtual--;
                    }
                }
            }
        }


    }
}
