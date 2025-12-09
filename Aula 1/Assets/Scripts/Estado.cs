using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Estado
    {

        public enum STATE
        {
            REPARANDO,
            ATACAR
        }
        List<STATE> state = new List<STATE>();
        
        public void Inserir(STATE estadoAtual)
        {
            state.Add(estadoAtual);
        }
        public void Retirar() 
        {
            if (state.Count > 1)
            {
                state.RemoveAt(state.Count - 1);
            }
            
        }
        public STATE GetState()
        {
            return state[state.Count -1];
        }
        public void Imprime()
        {
            for (int i = 0; i < state.Count; i++)
            {
                Debug.Log("LISTA: " + state[i]);
            }
        }
    }
}
