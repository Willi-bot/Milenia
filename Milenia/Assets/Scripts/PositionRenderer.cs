using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRenderer : MonoBehaviour
{
    [SerializeField]
    public int sortingOrderBase = 5000;
    [SerializeField] 
    private int offset = 0;
    [SerializeField] 
    private bool runOnlyOnce = false;

    private float _timer = 0;
    private float timerMax = .1f;
    public Renderer myRenderer;
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            _timer = timerMax;
            myRenderer.sortingOrder = (int) (sortingOrderBase - transform.position.y - offset);
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
