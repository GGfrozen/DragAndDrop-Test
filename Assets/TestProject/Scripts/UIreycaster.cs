#if UNITY_EDITOR
using  UnityEditor;
#endif
using System;
using System.Collections.Generic;
using  UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIreycaster : MonoBehaviour
{
   [SerializeField] private GraphicRaycaster raycaster;
   [SerializeField] private EventSystem eventSystem;

   private PointerEventData pointerEventData;
   
   #if UNITY_EDITOR
   private void Reset()
   {
      raycaster = GetComponent<GraphicRaycaster>();
      eventSystem = GetComponent<EventSystem>();
      if (raycaster == null || eventSystem == null)
      {
         EditorUtility.DisplayDialog("UI Raycaster", "Please add raycaster on canvas only", "ok");
         DestroyImmediate(this);
      }
   }
   #endif
   private void Update()
   {
      if (!Input.GetKeyDown(KeyCode.Mouse0))
      {
         return;
      }

      pointerEventData = new PointerEventData(eventSystem)
      {
         position = Input.mousePosition
      };
      var results = new List<RaycastResult>();
      raycaster.Raycast(pointerEventData,results);
      foreach (var raycastResult in results)
      {
         Debug.Log($"Hit{raycastResult.gameObject.name}");
      }

   }
}
