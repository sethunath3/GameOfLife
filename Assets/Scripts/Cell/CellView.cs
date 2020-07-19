using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.Cell
{
    public class CellView : MonoBehaviour
    {
        private CellController controller;
        public void SetController(CellController _controller)
        {
            controller = _controller;
        }

        public void UpdateColour (State state) {
		    if (state == State.Alive)
			    GetComponent<SpriteRenderer> ().color = Color.green;
		    else
			    GetComponent<SpriteRenderer> ().color = Color.white;
	    }

        void OnMouseDown()
        {
            if(controller != null)
            {
                controller.ToggleCellState();
            }
        }
    }
}
