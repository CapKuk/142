using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PictureHolderController : MonoBehaviour
{
    private static int id = 0;

    private RawImage rawImageL;
    private RawImage rawImageR;

    private string picURL_L;
    private string picURL_R;

    // Start is called before the first frame update
    void Start()
    {
        var transform = GetComponent<RectTransform>();
        rawImageL = this.transform.Find("RawImageLeft").GetComponent<RawImage>();
        rawImageR = this.transform.Find("RawImageRight").GetComponent<RawImage>();

        //transform.anchoredPosition = new Vector2(0, -1 * (height * 0.5f + id * height + id * spaser));

        //transform.sizeDelta = new Vector2(screenWeight, height);
        picURL_L = Model.baseURL + (2 * id + 1).ToString() + Model.baseFormat;
        picURL_R = Model.baseURL + (2 * id + 2).ToString() + Model.baseFormat;
        rawImageL.color = new Color(0, 0, 0);
        rawImageR.color = new Color(0, 0, 0);
        StartCoroutine(DownloadImage(picURL_L, rawImageL));
        StartCoroutine(DownloadImage(picURL_R, rawImageR));
        id++;
    }

    IEnumerator DownloadImage(string MediaUrl, RawImage imgHolder)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if ((int)request.result > 2)
            Debug.Log(request.error);
        else
        {
            imgHolder.color = new Color(255, 255, 255);
            imgHolder.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
