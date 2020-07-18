using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife.Cell
{
    public class CellView : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void UpdateColour (State state) {
		    if (state == State.Alive)
			    GetComponent<SpriteRenderer> ().color = Color.green;
		    else
			    GetComponent<SpriteRenderer> ().color = Color.white;
	    }
    }
}
