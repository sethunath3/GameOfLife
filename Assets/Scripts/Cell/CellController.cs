using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOfLife.Grid;

namespace GameOfLife.Cell
{
    public enum State 
    {
		Dead, 
        Alive
	}

    public class CellController
    {
        private CellView view;
        public State state;
	    private State nextState;

        private CellController[] neighbours;

        public CellController(int x, int y, GridController gridController)
        {
            view = GameObject.Instantiate<CellView>(gridController.GetCellPrefab(), new Vector2(0,0), Quaternion.identity);
            view.transform.position = new Vector2(0+((x-(gridController.GetNoOfRows()/2))*view.transform.localScale.x*gridController.GetCellGap()),0+((y-(gridController.GetNoOfColumns()/2))*view.transform.localScale.y*gridController.GetCellGap()));
            view.transform.parent = gridController.GetGridView().transform;
        }

        public void SetRandomState () 
        {
		    state = (UnityEngine.Random.Range (0.0f, 1.0f) < 0.5f) ? State.Dead : State.Alive;
		    view.UpdateColour (state);
	    }

        public void FindNextState()
        {
            int aliveCells = GetNoOfAliveNeighbours ();
		    if (state == State.Alive) 
            {
			    if (aliveCells < 2 || aliveCells > 3)
				    nextState = State.Dead;
		    } 
            else 
            {
			    if (aliveCells == 3)
				    nextState = State.Alive;
		    }
        }

        public void TickCell()
        {
            state = nextState;
		    view.UpdateColour (state);
        }

        private int GetNoOfAliveNeighbours () 
        {
		    int aliveCount = 0;
		    for (int i = 0; i < neighbours.Length; i++) 
            {
			    if (neighbours[i] != null && neighbours [i].state == State.Alive)
				    aliveCount++;
		    }
		    return aliveCount;
	    }

        public void SetNeighbours(CellController[] _neighbours)
        {
            neighbours = _neighbours;
        }

        public void KillCell(bool kill)
        {
            if(kill)
            {
                state = State.Dead;
                nextState = State.Dead;
            }
            else{
                state = State.Alive;
                nextState = State.Alive;
            }
            view.UpdateColour (state);
        }
    }
}

