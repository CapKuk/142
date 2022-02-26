using UnityEngine;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    [SerializeField] private GameObject imageHolder;
    [SerializeField] private ScrollRect galery;

    internal static readonly string baseURL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    internal static readonly string baseFormat = ".jpg";

    private float sumHeight = 0f;

    // Start is called before the first frame update
    void Start()
    {
        galery.verticalNormalizedPosition = 1;
        for (int i = 0; i < 10; i++)
        {
            var imageItem = Instantiate(imageHolder);
            imageItem.transform.SetParent(transform.parent, false);
            imageItem.transform.SetParent(galery.content);
            sumHeight += imageHolder.GetComponent<RectTransform>().sizeDelta.y + galery.content.GetComponent<VerticalLayoutGroup>().spacing;
        }
        sumHeight -= galery.GetComponent<RectTransform>().sizeDelta.y;
        Debug.Log(sumHeight);
        Debug.Log(imageHolder.GetComponent<RectTransform>().sizeDelta.y + galery.content.GetComponent<VerticalLayoutGroup>().spacing);
    }

    public void ValueChandged()
    {
        if(galery.content.transform.localPosition.y < 0)
        {
            galery.content.transform.localPosition = new Vector2(0, 0);
        }
        if(galery.content.transform.localPosition.y > sumHeight)
        {
            galery.content.transform.localPosition = new Vector2(0, sumHeight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
