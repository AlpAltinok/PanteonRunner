using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DikenliDikENGEL : MonoBehaviour
{
    public float rotationSpeed = 10f;
   
    public float baslangicX;  // Cismin ba�lang�� X pozisyonu
    public float hareketAraligi = 3.5f;  // Cismin gidip gelme aral���
    public float hiz;  // Cismin hareket h�z�

    private bool ileriYonde = true;

    void Update()
    {
       // transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        if (ileriYonde)
        {
            transform.Translate(Vector3.right * hiz * Time.deltaTime);  // Sa�a do�ru hareket

            // E�er cisim gidilecek aral���n sonuna ula�t�ysa, y�n�n� tersine �evir
            if (transform.position.x >= baslangicX + hareketAraligi)
            {
                ileriYonde = false;
            }
        }
        // Cisim ters y�nde hareket ediyor
        else
        {
            transform.Translate(Vector3.left * hiz * Time.deltaTime);  // Sola do�ru hareket

            // E�er cisim ba�lang�� noktas�na ula�t�ysa, y�n�n� tekrar tersine �evir
            if (transform.position.x <= baslangicX - hareketAraligi)
            {
                ileriYonde = true;
            }
        }

    }
}
