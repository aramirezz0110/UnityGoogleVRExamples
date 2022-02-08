using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    //variables para la resolucion
    public int resWidth = 3550;
    public int resHeight = 3550;

    private bool takeHiResShot = false;
    //devuelve el nombre del screenshot
    public static string ScreenShotName(int width, int heigth)
    {
        return string.Format("{0}/Screenshots/screen_{1}x{2}x{3}.png", 
            Application.dataPath,
            width, heigth,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
    public void TakeHiResShot()
    {
        takeHiResShot = true;
    }
    private void LateUpdate()
    {
        takeHiResShot |= Input.GetKeyDown("k");
        if (takeHiResShot)
        {
            RenderTexture rt = new RenderTexture(resWidth,resHeight,24);
            Camera.main.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            Camera.main.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            Camera.main.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
