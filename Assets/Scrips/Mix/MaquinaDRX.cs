using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDRX : MonoBehaviour
{
    bool animando = false;
    public Animator animPuerta;
    Collider col;

	private void OnTriggerEnter(Collider other)
	{
        ConvertidorMaterial cm = other.GetComponent<ConvertidorMaterial>();
        if (cm != null && !animando && col != other)
        {
            col = other;
            StartCoroutine(Animar(cm));
            animando = true;
		}
	}

    IEnumerator Animar(ConvertidorMaterial cm)
	{
        cm.transform.parent     = transform;
        cm.transform.localPosition = Vector3.zero;
        cm.agarradero.enabled   = false;
        cm.rb.isKinematic       = true;
        animPuerta.SetBool("abierta", false);
        yield return new WaitForSeconds(1);
        cm.rtx.IniciarAnimacion();
        yield return new WaitForSeconds(2);
        cm.Animar();
        yield return new WaitForSeconds(10);
        animPuerta.SetBool("abierta", true);
        cm.agarradero.enabled = true;
        animando = false;
    }
}
