using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOfLife.Cell;
using GameOfLife.Grid;

[CreateAssetMenu(menuName="ScriptableObjects/GridScriptableObject")]
public class GridScriptableObject : ScriptableObject
{
    [Range(6,100)]
    public int noOfRows;
    [Range(6,100)]
    public int noOfColumns;
    [Range(0.0f,10.0f)]
    public float cellGap;
    public CellView cellPrefab;
    public GridView gridPrefab;
}
