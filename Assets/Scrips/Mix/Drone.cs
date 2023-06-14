using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{
    public Transform pivote;
    public Estado estado;
    public float frecuencia = 1;
    public float amplitud = 0.5f;
    public float velocidad = 2;
    public Renderer rPantalla;
    public float angulosRutacion;
    public Transform hijo;

    public Texture[] texturasPantalla;
    Vector3 rotacionInicial;

    public Texture[] texturasAnimacion;
    public TMPro.TextMeshProUGUI txtMPro;
    public string[] textos;

    bool bloqueo;

    private Material material;
    public static Drone singleton;

	private void Start()
	{
        material = rPantalla.materials[1];
        StartCoroutine(Parpadear());
        StartCoroutine(Bienvenida());
        MostrarLetrero(6);
	}


	void Update()
    {
        Vector3 posObjetivo = pivote.position + Vector3.up * (Mathf.Sin(Time.time * frecuencia) * amplitud);
        transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pivote.rotation, velocidad * Time.deltaTime);
        hijo.localEulerAngles = Mathf.Cos(Time.time * frecuencia) * angulosRutacion * Vector3.forward;
    }

    public IEnumerator Parpadear()
    {
        while (true)
		{
            yield return new WaitForSeconds(Random.Range(2, 5));
			if (estado == Estado.idle)
			{
                CambiaTexturaCara(1);
                yield return new WaitForSeconds(0.2f);
                CambiaTexturaCara(0);
            }
        }
    }
    public IEnumerator Bienvenida()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            estado = Estado.hablando;
            for (int i = 2; i < 80; i++)
            {
                CambiaTexturaCara(i);
                yield return new WaitForSeconds(0.1f);
            }
            CambiaTexturaCara(0);
            estado = Estado.idle;
            yield return new WaitForSeconds(Random.Range(20, 80));
        }
    }

    public void CambiaTexturaCara(int cual)
	{
        material.mainTexture = texturasPantalla[cual];
        material.SetTexture("_EmissionMap", texturasPantalla[cual]);
    }

    public void MostrarLetrero(int cual)
	{
        StartCoroutine(Letrero(cual));
	}

    public IEnumerator Letrero(int cual)
    {
        yield return new WaitForSeconds(3);
        while ((transform.position - pivote.position).magnitude > 0.3f)
        {
            yield return null;
        }
		if (cual > 0)
		{
            txtMPro.text = textos[cual];
			if (!bloqueo)
			{
                bloqueo = true;
                //Activar Animación
                yield return new WaitForSeconds(10);
                //Desactivar Animación
                bloqueo = false;
			}

        }
    }
}

public enum Estado
{
    idle = 0,
    hablando = 1
}