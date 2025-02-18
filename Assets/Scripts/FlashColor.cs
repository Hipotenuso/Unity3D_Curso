using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [Header("Seyup")]
    public Color color = Color.red;
    public float duration = .1f;
    private Color defaultColor;
    private Tween _currTween;

    private void Start()
    {
        defaultColor = meshRenderer.material.GetColor("_BaseColor");
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(!_currTween.IsActive())
            _currTween = meshRenderer.material.DOColor(Color.red, "_BaseColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
