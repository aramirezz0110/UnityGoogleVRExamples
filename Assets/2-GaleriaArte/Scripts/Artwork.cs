using UnityEngine;

public class Artwork : MonoBehaviour
{
	[Header("Artworks")]
	//variable del tipo scriptable object
	public ArtworkSO artworkSO;
	//hace referencia al material
	private int materialId = 1;
	//para los cuadros
	MeshRenderer[] artworks;

	private void Start()
	{
		//para acceder a los materiales de todos los hijos
		artworks = GetComponentsInChildren<MeshRenderer>();
		//
		SetArtworks();
	}

	private void SetArtworks()
	{
		for (int i = 0; i < artworks.Length; i++)
		{
			//para acceder a la textura numero uno y aplicarle el material
			artworks[i].materials[materialId].mainTexture = artworkSO.artworks[i];
		}
	}

}