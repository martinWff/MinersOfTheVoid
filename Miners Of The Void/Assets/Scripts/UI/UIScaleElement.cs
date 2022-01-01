using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaleElement : MonoBehaviour
{
    private float width;
    public RectTransform rectTransform;
    public GridLayoutGroup group;
    public int factor = 8;
    // Start is called before the first frame update
    void Start()
    {
        width = rectTransform.rect.width;

    
        group.cellSize = new Vector2(width / factor, width / factor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
