using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertidorMaterial : MonoBehaviour
{
    public AnimationCurve tama;
    [Range(0f, 1f)]
    public float t;

    public Transform tPiedra;
    public Transform tMole;
    public float velAnimacion = 0.5f;
    float tAnimacion;
    bool animando;
    public RotaDRX rtx;
    public MonoBehaviour agarradero;
    public Rigidbody rb;

	private void Start()
	{
        rtx = GetComponent<RotaDRX>();
        tPiedra.localScale = Vector3.one * tama.Evaluate(1 - t);
        tMole.localScale = Vector3.one * tama.Evaluate(t);
    }

	public void Animar()
	{
        animando = true;
	}

    void Update()
    {
		if (animando)
		{
            tPiedra.localScale = Vector3.one * tama.Evaluate(1-t);
            tMole.localScale = Vector3.one * tama.Evaluate(t);
            tAnimacion += Time.deltaTime*velAnimacion;
            t = tAnimacion;
			if (tAnimacion > 1)
			{
                animando = false;
			}
		}
    }
}
