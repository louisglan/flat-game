using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite hoverSprite;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void OnMouseEnter()
    {
        spriteRenderer.sprite = hoverSprite;
    }

    public void OnMouseExit() {
        spriteRenderer.sprite = normalSprite;
    } 
}