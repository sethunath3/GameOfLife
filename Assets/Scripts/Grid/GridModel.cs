using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOfLife.Cell;

namespace GameOfLife.Grid
{
    public class GridModel
    {
        public int noOfRows;
        public int noOfColumns;
        public float cellGap;
        public CellView cellPrefab;
        public bool isCircularGrid;

        public GridModel(GridScriptableObject gridSO)
        {
            noOfRows = gridSO.noOfRows;
            noOfColumns = gridSO.noOfColumns;
            cellGap = gridSO.cellGap;
            cellPrefab = gridSO.cellPrefab;
            isCircularGrid = gridSO.isCircularGrid;
        }
    }
}

