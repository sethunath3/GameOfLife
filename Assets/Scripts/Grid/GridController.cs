using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOfLife.Cell;

namespace GameOfLife.Grid
{
    public class GridController
    {
        private GridModel model;
        private GridView view;
        public CellView cellPrefab;
        public CellController[,] cells; // array of cellControllers in grid

        public GridController(GridScriptableObject gridSO)
        {
            model = new GridModel(gridSO);
            view = GameObject.Instantiate(gridSO.gridPrefab, new Vector2(0,0), Quaternion.identity);
            SpawnCells();
        }

        void SpawnCells () {
            cells = new CellController[model.noOfRows, model.noOfColumns];
            for(int row = 0; row< model.noOfRows; row++)
            {
                for(int col = 0; col<model.noOfColumns; col++)
                {
                    cells[row, col] = new CellController(row, col, this);
                    cells[row, col].SetRandomState();
                }
            }

            for (int row = 0; row< model.noOfRows; row++) 
            {
			    for (int col = 0; col<model.noOfColumns; col++) 
                {
				    cells[row, col].SetNeighbours(GetNeighboursOf(row, col));
			    }
		    }
        }

        public CellController[] GetNeighboursOf(int x, int y) 
        {
            CellController[] neighbours = new CellController[8];

            neighbours[0] = cells[x, (y + 1) % model.noOfRows]; // top
            neighbours[1] = cells[(x + 1) % model.noOfColumns, (y + 1) % model.noOfRows]; // top right
            neighbours[2] = cells[(x + 1) % model.noOfColumns, y % model.noOfRows]; // right
            neighbours[3] = cells[(x + 1) % model.noOfColumns, (model.noOfRows + y - 1) % model.noOfRows]; // bottom right
            neighbours[4] = cells[x % model.noOfColumns, (model.noOfRows + y - 1) % model.noOfRows]; // bottom
            neighbours[5] = cells[(model.noOfColumns + x - 1) % model.noOfColumns, (model.noOfRows + y - 1) % model.noOfRows]; // bottom left
            neighbours[6] = cells[(model.noOfColumns + x - 1) % model.noOfColumns, y % model.noOfRows]; // left
            neighbours[7] = cells[(model.noOfColumns + x - 1) % model.noOfColumns, (y + 1) % model.noOfRows]; // top left
            
            return neighbours;
        }

        public CellView GetCellPrefab()
        {
            return model.cellPrefab;
        }

        public int GetNoOfRows()
        {
            return model.noOfRows;
        }

        public int GetNoOfColumns()
        {
            return model.noOfColumns;
        }

        public float GetCellGap()
        {
            return model.cellGap;
        }

        public GridView GetGridView()
        {
            return view;
        }

        public void TickGrid()
        {
            for(int row = 0; row< model.noOfRows; row++)
            {
                for(int col = 0; col<model.noOfColumns; col++)
                {
                    cells[row, col].FindNextState();	
                }
            }
            for(int row = 0; row< model.noOfRows; row++)
            {
                for(int col = 0; col<model.noOfColumns; col++)
                {
                    cells[row, col].TickCell ();	
                }
            }
        }

        public void RandomizeGrid()
        {
            for(int row = 0; row< model.noOfRows; row++)
            {
                for(int col = 0; col<model.noOfColumns; col++)
                {
                    cells[row, col].SetRandomState();
                }
            }
        }

        public void ClearGrid()
        {
            for(int row = 0; row< model.noOfRows; row++)
            {
                for(int col = 0; col<model.noOfColumns; col++)
                {
                    cells[row, col].KillCell(true);
                }
            }
        }
    }
}
