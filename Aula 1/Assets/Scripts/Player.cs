	using UnityEngine;

public class Player : MonoBehaviour
{
    enum STATE
    {
        PARADO,
        PERSEGUIR,
        PATRULHA,
        ATACAR
    }
    
    [SerializeField]STATE estado = STATE.PERSEGUIR;

    Vector3 pontoA = new Vector3(-8,0,0);
    Vector3 pontoB = new Vector3(8,2,0);
    int id = -1;
    float speed = 10;
    float timerPatrulha = 2f;
    float timerParado = 0f;
    float timerAtacar = 1f;

    [SerializeField] GameObject jogador;
    [SerializeField] GameObject tiro;

    public static int vida = 10;
    void Update()
    {
        timerParado += Time.deltaTime;
        timerAtacar += Time.deltaTime;
        Atualiza();
        Mudanca();
    }
    
    public void Mudanca()
    {
        switch (estado)
        {

            case STATE.PARADO:
                
                if(timerParado > 1f)
                {
                    timerParado = 0f;
                    estado = STATE.PATRULHA;
                }
                break;
            case STATE.PERSEGUIR:
                
                    break;
            case STATE.PATRULHA:
                if (Vector3.Distance(transform.position, jogador.transform.position) < 5f)
                {
                    estado = STATE.PERSEGUIR;
                }
                if (id == -1)
                {
                    if (Vector3.Distance(transform.position, pontoA) < 0.2f && timerParado > 2f)
                    {
                        estado = STATE.PARADO;
                        timerParado = 0;
                    }
                }
                else
                {
                    if (Vector3.Distance(transform.position, pontoB) < 0.2f && timerParado > 2f)
                    {
                        estado = STATE.PARADO;
                        timerParado = 0;
                    }
                }


                    break;
            case STATE.ATACAR:

                break;

        }
    }

    public void Atualiza()
    {
        switch (estado) 
        {
            case STATE.PARADO:
                //fica parado
                break;
            case STATE.PERSEGUIR:
                if (Vector3.Distance(transform.position,jogador.transform.position) < 5f)
                {
                    Vector3 direction = jogador.transform.position - transform.position;
                    transform.position += direction.normalized * speed * Time.deltaTime;
                    
                }
                else
                {
                    estado = STATE.PATRULHA;
                }
                if (Vector3.Distance(transform.position, jogador.transform.position) < 3f)
                {
                    estado = STATE.ATACAR;
                }

                    break;
            case STATE.PATRULHA:
                timerPatrulha -= Time.deltaTime;
                if(timerPatrulha < 0)
                {
                    id *= -1;
                    timerPatrulha = 2f;
                }
                if(id == -1)
                {
                    Vector3 direction = pontoA - transform.position;
                    transform.position += direction.normalized * speed * Time.deltaTime;
                }
                else
                {
                    Vector3 direction = pontoB - transform.position;
                    transform.position += direction.normalized * speed * Time.deltaTime;
                }
                    break;
            case STATE.ATACAR:
                if (timerAtacar > 2f)
                {
                    GameObject obj = Instantiate(tiro, transform.position, Quaternion.identity);
                    obj.GetComponent<Tiro>().direction = jogador.transform.position - transform.position;
                    timerAtacar = 0;
                    estado = STATE.PATRULHA;
                }
                break;
        
        }
    }

    public float Distancia(float X1, float X2, float Y1,float Y2)
    {
        float distancia = Mathf.Sqrt(Mathf.Pow(X2 - X1,2) - Mathf.Pow(Y2-Y1,2));
        return distancia;
    }

}
