﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    int numberVertex = 0;
    bool pressButtonMouse = false;
    LineRenderer line;

    // Start is called before the first frame update
    public void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    [System.Obsolete]
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressButtonMouse = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            pressButtonMouse = false;
        }

        if (pressButtonMouse)
        {
            CreateLine();
        }
        else
        {
            DeleteLine();
        }
    }

    [System.Obsolete]
    private void CreateLine()
    {
        line.SetVertexCount(numberVertex + 1);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.SetPosition(numberVertex, mousePosition);
        numberVertex++;
    }

    private void DeleteLine()
    {
        numberVertex = 0;
        line.SetVertexCount(0); 
    }
}
