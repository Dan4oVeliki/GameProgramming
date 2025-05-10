using UnityEngine;
using System.Collections;


public class EnemyBasic : MonoBehaviour //every enemy will have these
{

    public Material flashMaterial;

    public float duration;
    public MeshRenderer spriteRenderer;
    private Material originalMaterial;
    protected Coroutine flashRoutine;
    public bool hit=false;
    public float hp;
    public float dmg;

    public void Start()
    {
        spriteRenderer = GetComponent<MeshRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("MeshRenderer not found on the GameObject: " + gameObject.name);
            return;
        }
        originalMaterial = spriteRenderer.material;
        flashMaterial = new Material(flashMaterial);
    }
    public void Flash(Color color)
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine(color));
    }

    private IEnumerator FlashRoutine(Color color)
    {
        spriteRenderer.material = flashMaterial;
        flashMaterial.color = color;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }

    
    public virtual void DoAttack(float hp, bool hit)
    {
        hp -= dmg;
        hit = true;
    }
    public virtual void GetHit(float dmg)
    {
        Flash(Color.white);
    }
    public virtual void Dead()
    {
        Destroy(gameObject);
    }
}
