using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class HoverArrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Image theImg;

	public void OnPointerEnter(PointerEventData eventData)
	{
		//theText.color = Color.red; //Or however you do your color
		theImg.transform.position = new Vector2(theImg.transform.position.x,transform.position.y);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//theText.color = Color.white; //Or however you do your color
	}
}
