using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> canvases = new List<CanvasGroup>();
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        NextTutorial();
    }
    public void NextTutorial() {
        if (counter >= canvases.Count)
            return;
        Clear();
        canvases[counter].DOFade(1, 0.5f).OnComplete(() =>
        {
            counter++;
            StartCoroutine(waitToClear());
        });
    }
    private void Clear() { }
    IEnumerator waitToClear() {
        yield return new WaitForSeconds(3);
        foreach (var c in canvases)
        {
            c.alpha = 0;
        }
    }
}
