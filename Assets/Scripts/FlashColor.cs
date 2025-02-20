using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Header("Seyup")]
    public Color color = Color.red;
    public float duration = .1f;
    private Tween _currTween;

    void OnValidate()
    {
        if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
        if (skinnedMeshRenderer == null) skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }


    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(meshRenderer != null && ! _currTween.IsActive())
            _currTween = meshRenderer.material.DOColor(Color.red, "_BaseColor", duration).SetLoops(2, LoopType.Yoyo);

        if(skinnedMeshRenderer != null && !_currTween.IsActive())
            _currTween = skinnedMeshRenderer.material.DOColor(Color.red, "_BaseColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
