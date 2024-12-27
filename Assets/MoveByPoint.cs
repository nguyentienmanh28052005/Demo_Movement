using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MoveByPoint : MonoBehaviour
{
    public float _speed = 1f;
    public int _pointIndex = 0;
    public float _pointDistance = Mathf.Infinity;
    public Transform _pointHolder;
    public List<Transform> points;
    private void Start()
    {
        this.LoadPoints();
    }
    
    private void Update()
    {
        this.PointMoving();
    }

    private void FixedUpdate()
    {
        this.NextPointCalculate();
    }


    protected virtual void LoadPoints()
    {
        string name = transform.name + "_Points";
        this._pointHolder = GameObject.Find(name).transform;
        foreach (Transform point in this._pointHolder)
        {
            this.points.Add(point);
        }
    }

    // protected virtual void PointLerpMoving()
    // {
    //     float lerp_speed = 0.1f;
    //     Transform currentPoint = this.points[this._pointIndex];
    //     transform.position = Vector3.Lerp(transform.position, currentPoint.position, lerp_speed);
    // }

    protected virtual void PointMoving()
    {
        float step = this._speed * Time.deltaTime;
        Transform currentPoint = this.CurrentPoint();
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, step);
    }

    protected virtual void NextPointCalculate()
    {
        this._pointDistance = Vector3.Distance(transform.position, this.CurrentPoint().position);
        if (this._pointDistance == 0) this._pointIndex++;
        if (this._pointIndex >= this.points.Count) this._pointIndex = 0;
    }

    protected virtual Transform CurrentPoint()
    {
        return this.points[this._pointIndex];
    }
    
}