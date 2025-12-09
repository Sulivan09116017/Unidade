using Assets.Scripts;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public Vector3 direction = new Vector3(0,0,0);
    public float speed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Inimigo")
        {
            
            Player.vida -= 5;
            if(Player.vida <= 0) 
            {

                Unidade.estado.Retirar();
                Unidade.estado.Imprime();
                collision.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.tag == "Unidade")
        {
            if (Unidade.vida == 50)
            {
                Unidade.estado.Inserir(Estado.STATE.ATACAR);
            }
            Unidade.vida -= 1;
                       
           
        }
    }

}
