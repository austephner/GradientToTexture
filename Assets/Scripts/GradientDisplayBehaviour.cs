using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GradientDisplayBehaviour : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    
    [SerializeField] private GradientDirectionType _direction;
    
    [SerializeField] private Image _image;

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForEndOfFrame(); 
        
        _image.sprite = GradientToTexture.CreateSprite(
            _gradient, 
            _image.pixelsPerUnit, 
            _image.rectTransform.rect,
            _direction);
    }
}