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
        foreach (var c in canvases) {
            c.alpha = 0; 
        }
        canvases[counter].DOFade(1, 0.5f).OnComplete(() =>
        {
            canvases[counter].DOFade(1, 5f).OnComplete(() => {
                canvases[counter].DOFade(0, 0.5f);
                counter++;
            });
        });
    }
}
