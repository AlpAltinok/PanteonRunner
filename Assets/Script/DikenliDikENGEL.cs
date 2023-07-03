using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DikenliDikENGEL : MonoBehaviour
{
    public float rotationSpeed = 10f;
   
    public float baslangicX;  // Cismin baþlangýç X pozisyonu
    public float hareketAraligi = 3.5f;  // Cismin gidip gelme aralýðý
    public float hiz;  // Cismin hareket hýzý

    private bool ileriYonde = true;

    void Update()
    {
       // transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        if (ileriYonde)
        {
            transform.Translate(Vector3.right * hiz * Time.deltaTime);  // Saða doðru hareket

            // Eðer cisim gidilecek aralýðýn sonuna ulaþtýysa, yönünü tersine çevir
            if (transform.position.x >= baslangicX + hareketAraligi)
            {
                ileriYonde = false;
            }
        }
        // Cisim ters yönde hareket ediyor
        else
        {
            transform.Translate(Vector3.left * hiz * Time.deltaTime);  // Sola doðru hareket

            // Eðer cisim baþlangýç noktasýna ulaþtýysa, yönünü tekrar tersine çevir
            if (transform.position.x <= baslangicX - hareketAraligi)
            {
                ileriYonde = true;
            }
        }

    }
}
