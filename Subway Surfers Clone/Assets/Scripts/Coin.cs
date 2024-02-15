using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnEnable() 
    {
        transform.DORotate(new Vector3(0f,-180f,0),1f).SetLoops(-1,LoopType.Incremental);
    }


    private void OnTriggerEnter(Collider other)
    {
        transform.DOScale(Vector3.zero,0.2f).SetLoops(2,LoopType.Yoyo);
    }

}
