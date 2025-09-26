using System;
using UnityEngine;

public class SinhMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    
    protected virtual void Start()
    {
        //for override
    }
    
    protected virtual void OnEnable()
    {
        //for override
    }
    
    protected virtual void OnDisable()
    {
        //for override
    }
    
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    
    protected virtual void LoadComponents()
    {
        //for overriding   
    }
    
    protected virtual void ResetValue()
    {
        //for overriding
    }
}