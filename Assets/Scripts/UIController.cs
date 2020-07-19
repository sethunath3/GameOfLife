using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOfLife;

namespace GameOfLife
{
    public class UIController : MonoBehaviour
    {
        GameManager manager;
        void Start()
        {
            manager = GameObject.FindObjectOfType<GameManager>();
        }

        public void CB_OnTickClick()
        {
            manager.TickGame();
        }

        public void CB_OnRandomClick()
        {
            manager.RandomizeGrid();
        } 

        public void CB_OnClearClick()
        {
            manager.ClearGrid();
        } 
        
        public void CB_OnStartStopClick()
        {
            manager.ToggleAutoTick();
        }
    }
}
