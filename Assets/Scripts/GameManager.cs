using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOfLife.Grid;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GridScriptableObject gridSO;
    private GridController gridController;
    void Start()
    {
        gridController = new GridController(gridSO);
    }

    public void TickGame()
    {
        gridController.TickGrid();
    }

    public void RandomizeGrid()
    {
        gridController.RandomizeGrid();
    }

    public void ClearGrid()
    {
        gridController.ClearGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
