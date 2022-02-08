using System.Collections;
using Cinemachine;
using UnityEngine;
//librerias para el funcionamiento
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
	[Header("Timeline")]
	public int actualStep = 0; //primer paso del camino
	//LAS SIGUIENTES 2 VARIABLES DEBEN TENER LA MISMA CANTIDAD DE ELEMENTOS

	public int[] steps; //array para almacenar los pasos
	public TimelineAsset[] timelineAsset; //array para los timelines
	[Header("Complete")]
	public PlayableDirector playableDirector;
	public CinemachineDollyCart cart; //variable para el carrito
	public CinemachineSmoothPath path; //variable para el camino
	private void Start()
	{
		//es para el inicio del paseo, a futuro se puede emplear en un menu
		Play();
	}

	public void Play()
	{
		StartCoroutine(PlayTimeline());
	}

	IEnumerator PlayTimeline()
	{
		Debug.Log("<b>" + "START" + "</b>");
		//para verificar que los pasos sean menores que los del array 
		while (actualStep < steps.Length)
		{
			if (cart.m_Position > steps[actualStep])
			{
				Debug.Log("Step: " + actualStep.ToString()); //paso actual
				playableDirector.playableAsset = timelineAsset[actualStep];//reemplazo por otro timeline para mostrar otro planeta
				playableDirector.Play(); //ejecucion del timeline
				actualStep++;//continuar con los pasos
			}
			yield return null;
		}
		Debug.Log("<b>" + "WAITING" + "</b>");
		while (cart.m_Position < path.PathLength)
		{
			yield return null;
		}
		Debug.Log("<b>" + "END" + "</b>");
	}
}
