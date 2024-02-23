using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NulisAksara : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isDrawing = false;
    private Vector2 lastMousePosition;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            lineRenderer.positionCount = 0;
        }

        if (isDrawing && Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DrawLine(mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }

        // Deteksi saat pemain mengklik mouse
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDownAction();
        }

        // Deteksi saat pemain menarik mouse
        if (isDrawing && Input.GetMouseButton(0))
        {
            OnMouseDragAction();
        }

        // Deteksi saat pemain melepaskan tombol mouse
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }

    void DrawLine(Vector2 point)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, point);
    }

    void OnMouseDownAction()
    {
        isDrawing = true;
        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDragAction()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Lakukan sesuatu dengan perpindahan mouse, misalnya menggambar garis
        DrawLine(lastMousePosition, currentMousePosition);

        lastMousePosition = currentMousePosition;
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        // Implementasikan logika menggambar garis di sini
        Debug.DrawLine(start, end, Color.black, 0.1f);
    }
}


    

   