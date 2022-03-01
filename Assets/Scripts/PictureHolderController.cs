using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PictureHolderController : MonoBehaviour
{
    private static int id = 0;
    private int myId;

    private RawImage rawImageL;
    private RawImage rawImageR;

    private string picURL_L;
    private string picURL_R;

    // Start is called before the first frame update
    void Start()
    {
        var transform = GetComponent<RectTransform>();
        rawImageL = this.transform.Find("ButtonLeft").Find("RawImageLeft").GetComponent<RawImage>();
        rawImageR = this.transform.Find("ButtonRight").Find("RawImageRight").GetComponent<RawImage>();

        myId = id;

        this.transform.Find("ButtonLeft").GetComponent<Button>().onClick.AddListener(LeftButtonPressed);
        this.transform.Find("ButtonRight").GetComponent<Button>().onClick.AddListener(RightButtonPressed);

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
    private void LeftButtonPressed()
    {
        Debug.Log("LeftButton" + (2 * myId + 1));
        Model.NewScene(2 * myId + 1);
        id = 0;
    }

    private void RightButtonPressed()
    {
        Debug.Log("RightButton" + (2 * myId + 2));
        Model.NewScene(2 * myId + 2);
        id = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
