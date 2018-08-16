using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoytick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

    [SerializeField]
    private Image bgImg;
    [SerializeField]
    private Image joytickImg;

    public Vector3 InputDirection { get; set; }

    private void Awake()
    {
        bgImg = GetComponent<Image>();
        joytickImg = GetComponentsInChildren<Image>()[1];

        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            //Debug.Log(bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
            //Debug.Log(bgImg.rectTransform.sizeDelta.y);

            float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
            Debug.Log(InputDirection);
            joytickImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * bgImg.rectTransform.sizeDelta.x / 3, InputDirection.z * bgImg.rectTransform.sizeDelta.y / 3);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector3.zero;
        joytickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

}
