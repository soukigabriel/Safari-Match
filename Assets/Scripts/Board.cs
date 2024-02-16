using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] GameObject emptyTilePrefab;
    [SerializeField] private float cameraSizeMargin;
    [SerializeField] private float cameraVerticalOffset;

    // Start is called before the first frame update
    void Start()
    {
        SetupBoard();
        SetCameraPosition();
        SetCameraSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupBoard()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                GameObject emptyTile = Instantiate(emptyTilePrefab, new Vector3(x, y, -5), Quaternion.identity);
                emptyTile.transform.parent = transform;
            }
        }
    }

    private void SetCameraSize()
    {
        float horizontalSize = width + cameraSizeMargin;
        float verticalSize = (height / 2) + cameraSizeMargin;

        Camera.main.orthographicSize = horizontalSize > verticalSize ? horizontalSize : verticalSize;
    }

    private void SetCameraPosition()
    {
        float newPositionX = (float)width / 2f;
        float newPositionY = (float)height / 2f;

        Camera.main.transform.position = new Vector3(newPositionX - 0.5f, newPositionY - 0.5f + cameraVerticalOffset, -10f);
    }
}
