using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Transform pivote;
    public float frecuencia = 1;
    public float amplitud = 0.5f;
    public float velocidad = 2;

    void Update()
    {
        Vector3 posObjetivo = pivote.position + Vector3.up * (Mathf.Sin(Time.time * frecuencia) * amplitud);
        transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pivote.rotation, velocidad * Time.deltaTime);
    }
}
