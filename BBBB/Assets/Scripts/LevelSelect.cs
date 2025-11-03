using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class LevelSelect : MonoBehaviour
{
    public RectTransform arrow;
    public RectTransform oceanSide;
    public RectTransform swamp;
    public RectTransform lavaPond;
    public RectTransform helpFather;
    public RectTransform back;
    private RectTransform _mousePosition;
    private Vector2 _mouseScreenPosition;

    public EventSystem _EventSystem;
     public RectTransform _rectTransform;

    private void Start()
    {
        _EventSystem.firstSelectedGameObject = oceanSide.gameObject;
        
        _EventSystem.SetSelectedGameObject(oceanSide.gameObject);
        
        
        if (_rectTransform == null)
        {
            _rectTransform = _EventSystem.currentSelectedGameObject.GetComponent<RectTransform>();
        }
    }

    private void Update()
    {
        var arrowPosition = arrow.position;
        arrowPosition.y = _rectTransform.position.y;
        arrow.position = arrowPosition;
        
        // Get Current Selected GameObject Rect Transform
        _rectTransform = _EventSystem.currentSelectedGameObject.GetComponent<RectTransform>();
    }
    
    public void SelectButton(RectTransform transform)
    {
        // Set current Selected Object to Mouse Hover
        _EventSystem.SetSelectedGameObject(transform.gameObject);
        
        var arrowPosition = arrow.position;
        arrowPosition.y = transform.position.y;
        arrow.position = arrowPosition;
        
   
       // arrow.position = new Vector2(transform.position.x -5f, transform.position.y);
    }
}
