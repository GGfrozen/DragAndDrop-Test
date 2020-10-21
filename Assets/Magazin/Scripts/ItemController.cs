using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ItemController : MonoBehaviour,IDropHandler
{
    [SerializeField] private Owner owner;
    
     private Items _item;
     private Image _image;
     private SellController _sellController;

     public void SetItem(Items item)
     {
         _item = item;
     }

     public void RemoveItem()
     {
         _item = null;
     }

     private void Start()
     {
         _image = GetComponent<Image>();
         _sellController = FindObjectOfType<SellController>();
         var chance = Random.Range(0, 100);
         if (chance > 50)
         {
             GameObject itemObj = SpriteStorage.instance.item;
             InventoryItem inventoryItem = Instantiate(itemObj, itemObj.transform.parent, false).GetComponent<InventoryItem>();
             inventoryItem.transform.position = transform.position;
             inventoryItem.SetParent(this);
             _image.sprite = SpriteStorage.instance.GetSellSprite(SpriteStorage.SellType.Full);
         }
     }
     public void OnDrop(PointerEventData eventData)
     {
         if (eventData.pointerDrag != null)
         {
             InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
             bool canMove = true;
             if (inventoryItem.GetParent().owner != owner)
             {
                 if (inventoryItem.GetParent().owner == Owner.Player)
                 {
                     canMove = _sellController.BuyItem(inventoryItem.GetItem());
                 }
                 else
                 {
                     canMove = _sellController.SellItem(inventoryItem.GetItem());
                 }
             }

             if (canMove)
             {
                 eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                     GetComponent<RectTransform>().anchoredPosition;
                 _image.sprite = SpriteStorage.instance.GetSellSprite(SpriteStorage.SellType.Full);
                 ItemController parent = eventData.pointerDrag.GetComponent<InventoryItem>().GetParent();
                 if (parent != null)
                 {
                     parent._image.sprite = SpriteStorage.instance.GetSellSprite(SpriteStorage.SellType.Empty);
                 }

                 eventData.pointerDrag.GetComponent<InventoryItem>().SetParent(this);
             }
             else
             {
                 inventoryItem.MoveBack();
             }
         }
     }
}
