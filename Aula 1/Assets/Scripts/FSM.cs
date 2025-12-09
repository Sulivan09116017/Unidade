using UnityEngine;

public class FSM : MonoBehaviour
{
    enum STATE
    {
        ESQUERDA,
        DIREITA,
        CIMA,
        BAIXO
    }

    [SerializeField]STATE state = STATE.ESQUERDA;
    [SerializeField]float speed = 20;
    float time = 1f;
    
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0f) 
        {
            ChangeState();
            time = 1f;
        }

        UpdateState();
    }

    public void ChangeState()
    {
        int r = Random.Range(0, 4);
        switch (state) 
        {
            case STATE.ESQUERDA:
                switch (r)
                {
                    case 0: 
                        state = STATE.CIMA; 
                        break;
                    case 1:
                        state = STATE.DIREITA;
                        break;
                    case 2:
                        state = STATE.BAIXO;
                        break;
                }
                break;
            case STATE.CIMA:
                switch (r)
                {
                    case 0:
                        state = STATE.ESQUERDA;
                        break;
                    case 1:
                        state = STATE.DIREITA;
                        break;
                    case 2:
                        state = STATE.BAIXO;
                        break;
                }
                break;
            case STATE.DIREITA:
                switch (r)
                {
                    case 0:
                        state = STATE.ESQUERDA;
                        break;
                    case 1:
                        state = STATE.CIMA;
                        break;
                    case 2:
                        state = STATE.BAIXO;
                        break;
                }
                break;
            case STATE.BAIXO:
                switch (r)
                {
                    case 0:
                        state = STATE.ESQUERDA;
                        break;
                    case 1:
                        state = STATE.CIMA;
                        break;
                    case 2:
                        state = STATE.DIREITA;
                        break;
                }
                break;
        }
    }

    public void UpdateState()
    {
        switch (state)
        {
            case STATE.ESQUERDA:
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                break;
            case STATE.DIREITA:
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                break;
            case STATE.BAIXO:
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                break;
            case STATE.CIMA:
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                break;
        }
    }
}
