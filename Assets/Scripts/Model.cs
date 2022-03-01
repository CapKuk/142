using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    [SerializeField] private GameObject imageHolder;
    [SerializeField] private ScrollRect galery;

    internal const string baseURL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    internal const string baseFormat = ".jpg";
    internal static int pictureId;

    private float sumHeight = 0f;
    private int currentId = 0;

    // Start is called before the first frame update
    void Start()
    {
        galery.verticalNormalizedPosition = 1;
        for (int i = 0; i < 4; i++)
        {
            AddItem();
        }
        sumHeight -= galery.GetComponent<RectTransform>().sizeDelta.y;
    }

    private void AddItem()
    {
        var imageItem = Instantiate(imageHolder);
        imageItem.transform.SetParent(transform.parent, false);
        imageItem.transform.SetParent(galery.content);
        sumHeight += imageHolder.GetComponent<RectTransform>().sizeDelta.y + galery.content.GetComponent<VerticalLayoutGroup>().spacing;
        currentId++;
    }

    public void ValueChandged()
    {
        if(galery.content.transform.localPosition.y < 0)
        {
            galery.content.transform.localPosition = new Vector2(0, 0);
        }
        if(galery.content.transform.localPosition.y > sumHeight)
        {
            if(currentId < 33)
            {
                AddItem();
            }
            else
            {
                galery.content.transform.localPosition = new Vector2(0, sumHeight);
            }
        }
    }

    internal static void NewScene(int id)
    {
        SceneManager.LoadScene("ShowPictureScene");
        pictureId = id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
