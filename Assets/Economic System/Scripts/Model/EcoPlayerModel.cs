using UnityEngine;

public class EcoPlayerModel : MonoBehaviour
{
    public EcoPlayerData data { get; private set; }

    #region mono functions

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        UpdatePos();
    }

    #endregion mono functions

    #region base function

    public void Init(EcoPlayerData data)
    {
        this.data = data;
    }

    #endregion base function

    #region functions

    void UpdatePos()
    {
        transform.position = data.localPos;
    }

    #endregion functions
}
