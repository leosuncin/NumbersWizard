using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection; 
using System;

public class NumbersWizard : MonoBehaviour
{
	private int max = 1000;
	private int min = 1;
	private int center;

	// Use this for initialization
	void Start ()
	{
		BeginGame ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = center < 1000 ? center + 1 : center;
			Ask ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = center - 1;
			Ask ();
		} else if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)) {
			print ("Adivine, es " + center + "\nPresiona R para reiniciar");
		} else if (Input.GetKeyDown (KeyCode.R)) {
			min = 1;
			max = 1000;
			BeginGame ();
		}/* else {
			print ((string) Input.inputString);
		}*/
	}

	private void BeginGame ()
	{
		ClearLog ();
		print ("Bienvenido al Adivinador de numeros\nEscoge un  numero en tu cabeza, ¡pero no me lo digas!");
		
		print ("El numero maximo que puedes escoger es " + this.max + "\nEl numero mas bajo que puedes escoger es " + this.min);

		Ask ();
	}

	private void Ask ()
	{
		center = (max - min) / 2 + min;
		print ("¿Es el numero mayor o menor que " + center + "?\nArriba: mayor que, abajo: menor que, Enter: igual");
	}

	private void ClearLog()
	{
		var assembly = Assembly.GetAssembly(typeof(UnityEditor.ActiveEditorTracker));
		var type = assembly.GetType("UnityEditorInternal.LogEntries");
		var method = type.GetMethod("Clear");
		method.Invoke(new object(), null);
	}
}
