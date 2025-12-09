using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    void Start()
    {
        for(int i = 0;i < 300; i++)
        {
            Instantiate(objeto);
        }
    }
}
