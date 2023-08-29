using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaDRX : MonoBehaviour
{
    public float tiempoRotacion = 2;
	public float velrotacion = 50;
    public AnimationCurve curvaRotacion;
	Quaternion rotInicial;

	int interacciones = 0;
	[ContextMenu("iniciar")]
	public void IniciarAnimacion()
	{
		StartCoroutine(StartAnimation());
	}
    IEnumerator StartAnimation()
    {
		rotInicial = transform.rotation;
		for (int i = 0; i < 10; i++)
		{
			StartCoroutine(Rotar());
			yield return new WaitForSeconds(Random.Range(1, 3));
		}
    }

    IEnumerator Rotar()
	{
		interacciones++;
        Vector3 v = Vector3.zero;
		float r = Random.Range(0f, 1f);
		if (r < 0.3f)
            v.x = 1;
		else if (r < 0.6f)
			v.y = 1;
		else
			v.z = 1;

		float t = 0;
		while (tiempoRotacion>t)
		{
			t += Time.deltaTime;
			yield return new WaitForSeconds(Time.deltaTime);
			transform.Rotate(v * velrotacion * curvaRotacion.Evaluate(t / tiempoRotacion)*Time.deltaTime);
		}
		interacciones--;
		if (interacciones == 0)
		{
			for (int i = 0; i <= 100; i++)
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, rotInicial, 0.05f);
				yield return null;
			}
		}

		
	}
}
