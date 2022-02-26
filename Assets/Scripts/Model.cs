using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    [SerializeField] private GameObject imageHolder;

    internal static readonly string baseURL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    internal static readonly string baseFormat = ".jpg";
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            var imageItem = Instantiate(imageHolder);
            imageItem.transform.SetParent(transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
