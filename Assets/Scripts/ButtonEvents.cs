using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;




public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private Transform rotationImage;
    private Sequence sequence;

    public void Select()
    {
        transform.localScale = Vector3.one * 1.2f;
    }

    public void Deselect()
    {
        transform.localScale = Vector3.one;
    }

    public void UpdateSelected()
    {
        rotationImage.Rotate(Time.deltaTime*90f * Vector3.forward);
    }

    public void Move()
    {
        sequence?.Kill();
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one * 0.8f, 0.3f))
            .Append(transform.DOScale(Vector3.one, 0.3f));
    }

    public void Submit()
    {
        
        Debug.Log("Submit!");
    }

    public void Cancel()
    {
        Debug.Log("Cancel!");
    
    }
}
