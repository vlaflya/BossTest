using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using static BulletCollision;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletCollision collider;
    [SerializeField] private BulletHitter hitter;
    [SerializeField] private float timeOut;
    [SerializeField] private BulletMover mover;
    [SerializeField] private bool hasTimeOver = true;
    public UnityEvent onShoot = new UnityEvent();
    private float timer;
    private Transform shootPoint;
    private Vector3 nullPos;
    public bool active;
    private Vector3 startScale;
    private List<BulletController> notActiveBullets;
    private void Start()
    {
        startScale = transform.localScale;
        collider.onCollision.AddListener(Hit);
        hitter.onDie.AddListener(Disable);
    }
    private void Update()
    {
        if (!active)
            return;
        if (!hasTimeOver)
            return;
        timer += Time.deltaTime;
        if (timer >= timeOut) {
            transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            {
                timer = 0;
                Disable();
            });
        }
    }

    private void FixedUpdate()
    {
        if (!active)
            return;
        if(mover != null)
            mover.Move();
    }

    public void OnInst(ref List<BulletController> notActive, Vector3 nullPos, Transform point) {

        shootPoint = point;
        this.nullPos = nullPos;
        transform.position = nullPos;
        notActiveBullets = notActive;
        notActiveBullets.Add(this);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void Shoot() {
        timer = 0;
        transform.localScale = startScale;
        transform.position = shootPoint.position;
        transform.rotation = shootPoint.rotation;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        notActiveBullets.Remove(this);
        active = true;
        if (onShoot != null)
            onShoot.Invoke();
    }

    private void Hit(TriggerParams param) {
        if (!active)
            return;
        if(param != null)
            hitter.Hit(param);
    }
    public virtual void Disable() {
        active = false;
        if (notActiveBullets == null)
        {
            Destroy(gameObject);
            return;
        }
        notActiveBullets.Add(this);
        transform.position = nullPos;
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }
}
