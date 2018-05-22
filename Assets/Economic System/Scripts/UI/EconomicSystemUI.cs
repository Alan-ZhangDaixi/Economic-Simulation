using System.Collections.Generic;
using UnityEngine;

public class EconomicSystem : MonoBehaviour
{
    #region Mono Functions

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion Mono Functions

    #region base 

    void Init()
    {
        data = new EconomicSystemData();

    }

    #endregion base

    #region data

    public EconomicSystemData data;

    #endregion data
}
