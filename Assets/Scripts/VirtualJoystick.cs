
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Virtual joystick for mobile joystick control
/// </summary>
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image backPanel;
    private Image knob;

    public Vector2 InputDirection { get; set; }

    /// <summary>
    /// Get the joystick UI.
    /// </summary>
    private void Start()
    {
        backPanel = GetComponent<Image>();
        knob = transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        // move the joystick if the input position is outside the joystick's bounds
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (!this.GetComponent<Image>().rectTransform.rect.Contains(Input.touches[0].position))
                this.transform.position = Input.touches[0].position;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse position: " + Input.mousePosition);
            Debug.Log(this.GetComponent<Image>().transform.position);
            Debug.Log("Image rect: " + this.GetComponent<Image>().rectTransform.rect);

            if (!this.GetComponent<Image>().rectTransform.rect.Contains(Input.mousePosition))
            {
                this.transform.position = Input.mousePosition;
                Debug.Log("outside rect");
            }
        }
    }

    /// <summary>
    /// Drag the knob of the joystick.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnDrag(PointerEventData pointerEventData)
    {
        Vector2 position = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (backPanel.rectTransform,
                pointerEventData.position,
                pointerEventData.pressEventCamera,
                out position))
        {
            // Get the touch position
            position.x /= backPanel.rectTransform.sizeDelta.x;
            position.y /= backPanel.rectTransform.sizeDelta.y;

            //// Calculate the move position
            //float x = (backPanel.rectTransform.pivot.x == 1) ?
            //    position.x * 2 + 1 : position.x * 2 - 1;
            //float y = (backPanel.rectTransform.pivot.y == 1) ?
            //    position.y * 2 + 1 : position.y * 2 - 1;

            // Get the input position
            InputDirection = new Vector2(position.x, position.y);
            InputDirection = (InputDirection.magnitude > 1) ?
                InputDirection.normalized : InputDirection;

            // Move the knob
            knob.rectTransform.anchoredPosition =
                new Vector2(InputDirection.x * (backPanel.rectTransform.sizeDelta.x / 3),
                    InputDirection.y * (backPanel.rectTransform.sizeDelta.y / 3));
        }
    }

    /// <summary>
    /// Click on the knob.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnPointerDown(PointerEventData pointerEventData)
    {
        OnDrag(pointerEventData);
    }

    /// <summary>
    /// Click off the knob.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnPointerUp(PointerEventData pointerEventData)
    {
        InputDirection = Vector2.zero;
        knob.rectTransform.anchoredPosition = Vector2.zero;
    }
}