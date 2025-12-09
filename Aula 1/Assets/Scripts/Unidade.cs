using Assets.Scripts;
using UnityEngine;

public class Unidade : MonoBehaviour
{
    public static Estado estado = new Estado();
    [SerializeField]GameObject inimigo;
    [SerializeField] GameObject tiro;

    public static int vida = 50;
    float timerAtacar = 0;
    void Start()
    {
        estado.Inserir(Estado.STATE.REPARANDO);
        estado.Imprime();
    }

    
    void Update()
    {
        timerAtacar += Time.deltaTime;
        UpdateState();
        
    }
    public void UpdateState()
    {
        switch (estado.GetState()) 
        { 
            case Estado.STATE.REPARANDO:
                
                break;
            case Estado.STATE.ATACAR:
                if (timerAtacar > 2f)
                {
                    GameObject obj = Instantiate(tiro, transform.position, Quaternion.identity);
                    obj.GetComponent<Tiro>().direction = inimigo.transform.position - transform.position;
                    timerAtacar = 0;
                }
                break;
        }

    }
}
