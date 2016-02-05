using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	private Canvas canvas;
	private Transform cardHand;
	Vector3 startPosition;

	public void Start() {
		canvas = GetComponentInParent<Canvas> ();
		cardHand = transform.parent;
	}
		
	void OnMouseEnter() {
		Debug.Log (transform.position);
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		transform.SetParent (canvas.transform, true);
		startPosition = transform.position;
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	#endregion

	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData)
	{
		transform.SetParent(cardHand);
		transform.position = startPosition;
	}
	#endregion
}
