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

    private RawImage rawImage;

    private string picURL;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
        var transform = GetComponent<RectTransform>();
        id++;
        if (id % 2 == 1)
        {
            transform.anchorMin = new Vector2(0, 1);
            transform.anchorMax = new Vector2(0, 1);
            transform.pivot = new Vector2(0.5f, 0.5f);

            transform.anchoredPosition = new Vector2(height * 0.5f, -(height * 0.5f + (id - 1) * 0.5f * (height + spaser)));
        }
        else
        {
            transform.anchorMin = new Vector2(1, 1);
            transform.anchorMax = new Vector2(1, 1);
            transform.pivot = new Vector2(0.5f, 0.5f);

            transform.anchoredPosition = new Vector2(-height * 0.5f, -(height * 0.5f + (id - 2) * 0.5f * (height + spaser)));
        }

        transform.sizeDelta = new Vector2(200, 200);
        picURL = Model.baseURL + id + Model.baseFormat;
        rawImage.color = new Color(0, 0, 0);
        StartCoroutine(DownloadImage(picURL));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if ((int)request.result > 2)
            Debug.Log(request.error);
        else
        {
            rawImage.color = new Color(255, 255, 255);
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
