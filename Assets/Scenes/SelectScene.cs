using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
public class SelectScene : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name=="0-MainScene")
        {
            StartCoroutine(Enable2DView());
        }
        else
        {
            StartCoroutine(EnableVRView());
        }
    }
    public IEnumerator Enable2DView()
    {
        Debug.Log("2D view is active!");
        XRSettings.LoadDeviceByName("None");
        yield return null;
        XRSettings.enabled = false;
    }
    public IEnumerator EnableVRView()
    {
        Debug.Log("3D VR view is active!");
        XRSettings.LoadDeviceByName("Cardboard");
        yield return null;
        XRSettings.enabled = true;
        Debug.Log("VR view up");
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name!="0-MainScene")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                //volver a la escena principal
                LoadSceneByCase(0);   
            }
        }
    }
    //cargar escenas
    public void LoadSceneByCase(int scene)
    {
        switch (scene)
        {
            case 0: //menu
                {
                    SceneManager.LoadScene("0-MainScene");
                    break;
                }
            case 1: //inmobiliaria
                {
                    SceneManager.LoadScene("1-Inmobiliaria");
                    break;
                }
            case 2: //galeria
                {
                    SceneManager.LoadScene("2-GaleriaDeArte");
                    break;
                }
            case 3: //educacion
                {
                    SceneManager.LoadScene("3-Educacion");
                    break;
                }
            case 4: //educacion
                {
                    SceneManager.LoadScene("4-Caminata");
                    break;
                }
        }
    }
    //volver al menu
}
