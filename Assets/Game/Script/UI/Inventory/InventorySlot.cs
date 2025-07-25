using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler 
{

	public Image icon;
	public Text quantityText;

	private ItemData currentItem;

	public ItemData itemData;

	private Transform originalParent;
	private Vector2 originalPos;

	public void ClearItem() {
		itemData = null;
		icon.sprite = null;
		icon.enabled = false;
		quantityText.text = "";
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			Debug.Log("Left click on slot");
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			Debug.Log("Right click → show context menu");
			// InventoryUI.Instance.ShowContextMenu(this, eventData.position);
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("Bắt đầu kéo item");
		// Ghi nhớ item đang kéo, tạo bản sao ảnh nếu cần
	}

	public void OnDrag(PointerEventData eventData)
	{
		// Di chuyển hình ảnh item theo con trỏ
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("Kết thúc kéo item");
		// Ẩn hình ảnh kéo, nếu không thả vào đâu thì trả lại
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("Thả item vào slot này");
		// Hoán đổi item giữa 2 slot
	}

	public void SetItem(ItemData item) {
		currentItem = item;
		icon.sprite = item.icon;
		quantityText.text = item.quantity.ToString();
		icon.enabled = true;
	}

	public bool IsEmpty() {
		return currentItem == null;
	}

	public void UseItem() {
		if (currentItem != null) {
			// Gọi hàm sử dụng item
		}
	}


}
