using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool needReload;
    [SerializeField] private int clipSize;
    public string intarfaceName;
    private int bulletCount = 0;
    public void PullTrigger() {
        if (animator == null)
            return;
        if (needReload)
        {
            bulletCount++;
            if (bulletCount > clipSize) {
                bulletCount = 0;
                animator.SetTrigger("Reload");
                return;
            }
        }
        animator.SetTrigger("Shoot");
    }
}
