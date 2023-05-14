using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] List<Transform> positions;

    private void Start()
    {
        Move();
    }

    int index;
    private void Move()
    {
        //biat obstacle bolak-balik
        var pos = positions[index];
        this.transform.DOMove(pos.position, 1).onComplete = Move;
        index += 1;
        if (index == positions.Count) index = 0;
    }
}
