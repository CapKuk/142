using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PictureHolderController : MonoBehaviour
{
    private static int id = 0;
    private static readonly float height = 200;
    private static readonly float spaser = 50;
    private static readonly float screenWeight = 480;

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

        transform.anchoredPosition = new Vector2(0, -1 * (height * 0.5f + id * height + id * spaser));
        /*
        100
        100 + 200 + 50
        100 + 2 * 200 + 2 * 50
        100 + 3 * 200 + 3 * 50
         */

        transform.sizeDelta = new Vector2(screenWeight, height);
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
