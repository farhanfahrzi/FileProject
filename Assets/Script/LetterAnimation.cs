using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAnimation : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleFactor = 1.5f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckTouch(Input.GetTouch(0).position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CheckTouch(Input.mousePosition);
        }
    }

    void CheckTouch(Vector2 touchPosition)
    {
        // Konversi posisi layar ke dunia
        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(touchWorldPosition);

        if (hitCollider != null && hitCollider.gameObject == gameObject)
        {
                // Memulai animasi jika objek yang ditekan adalah huruf
                StartCoroutine(AnimateLetter());
        }
    }

    IEnumerator AnimateLetter()
    {
            // Animasi membesar
            transform.localScale = originalScale * scaleFactor;

            // Tunggu sejenak
            yield return new WaitForSeconds(1f);

            // Kembalikan ke skala asli
            transform.localScale = originalScale;
    }
}


    
