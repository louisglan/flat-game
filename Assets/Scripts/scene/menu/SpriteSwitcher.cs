using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite hoverSprite;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void OnMouseEnter()
    {
        UseHoverSprite();
    }

    public void OnMouseExit()
    {
        UseNormalSprite();
    }

    public void UseHoverSprite()
    {
        _spriteRenderer.sprite = hoverSprite;
    }

    public void UseNormalSprite()
    {
        _spriteRenderer.sprite = normalSprite;
    }
}