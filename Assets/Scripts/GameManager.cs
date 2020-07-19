using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOfLife.Grid;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GridScriptableObject gridSO;
    private GridController gridController;
    private float elapsed = 0f; 
    private bool autoTickEnabled = false;
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

    public void ToggleAutoTick()
    {
        autoTickEnabled = !autoTickEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(autoTickEnabled)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f) 
            {
                elapsed = elapsed % 1f;
                TickGame();
            }
        }
    }
}
