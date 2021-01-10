using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu("Nokia 3310/Add Camera Resolution")]
public class NokiaVirtualResolution : MonoBehaviour
{
    public int w = 84;
    public int h = 48;
    private int w_screen;
    private int h_screen;
    private float aspRatio;

    public Camera cam;

    // protected void Start()
    // {
    // 	cam = GetComponent<Camera>();
    	
    //     if (!SystemInfo.supportsImageEffects)
    //     {
    //         enabled = false;
    //         return;
    //     }
    // }

    // void Update()
    // {
    //     w_screen = w;
    //     h_screen = h;

    //     aspRatio = ((float)cam.pixelHeight / (float)cam.pixelWidth);

    //     if (aspRatio < 1f) 
    //         // landscape
    //         h_screen = Mathf.RoundToInt(w * aspRatio);
    //     else
    //         // portrait
    //         w_screen = Mathf.RoundToInt(h / aspRatio);
    // }
    
    // void OnRenderImage(RenderTexture source, RenderTexture destination)
    // {
    //     source.filterMode = FilterMode.Point;
    //     RenderTexture buffer = RenderTexture.GetTemporary(w_screen, h_screen, -1);
    //     buffer.filterMode = FilterMode.Point;
    //     Graphics.Blit(source, buffer);
    //     Graphics.Blit(buffer, destination);
    //     RenderTexture.ReleaseTemporary(buffer);
    // }
}
