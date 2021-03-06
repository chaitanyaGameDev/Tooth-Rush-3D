using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class Ground : MonoBehaviour
{

    [SerializeField] GroundPieceType m_GroundPieceType;
    [Space(15)]
    [SerializeField] List<GroundPieceSlot> m_Slots;


    

    public PathCreator PathCreator { private set; get; }
 
    //----------------------------------------------Variables-----------------------------------------------

    private void OnValidate()
    {
        EnableGroundPiece();
    }
    private void Start()
    {
        EnableGroundPiece();
        
    }
    private void EnableGroundPiece()
    {
        foreach (var item in m_Slots)
        {
            if (item.GroundPieceType == m_GroundPieceType && item.GroundMeshObj != null)
            {
                

                item.GroundMeshObj.SetActive(true);
                PathCreator = item.GroundMeshObj.GetComponent<PathCreator>();
            }
            else if(item.GroundMeshObj != null)
            {
                item.GroundMeshObj.SetActive(false);
            }

        }
    }

    //----------------------------------------------Methods--------------------------------------------------

}
public enum GroundPieceType
{
    Straight_10m,
   
    Straight_20m,
    Straight_30m,
    CurveLeft,
    CurveRight
}
[System.Serializable]
public class GroundPieceSlot
{
    public GroundPieceType GroundPieceType;
    public GameObject GroundMeshObj;
   
}