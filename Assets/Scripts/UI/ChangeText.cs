using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    private Text _text;
    private CanvasGroup _canvasGroup;
    public float alpha = 1.0f;
    private RectTransform _rectTransform;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        _rectTransform.localPosition = new Vector2(_rectTransform.localPosition.x,
            _rectTransform.localPosition.y + 5f);
        if (_canvasGroup.alpha <= 0f)
            Destroy(this.gameObject);
    }

    public IEnumerator Show(float value)
    {
        if (_text == null)
            yield return 0;
        DOTween.To(value =>
        {
            if (_canvasGroup)
            {
                _canvasGroup.alpha = value;
            }
        }, 1, 0, 1.0f);
        if (value > 0)
        {
            _text.color = Color.green;
            _text.text = "+" + value;
        }
        else
        {
            _text.color = Color.red;
            _text.text = value.ToString();
        }
    }
}