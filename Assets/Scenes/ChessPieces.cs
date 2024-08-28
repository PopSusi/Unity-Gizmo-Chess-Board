using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum MyType { Rook, Queen, Knight, King, Bishop, Pawn };

public class ChessPieces : MonoBehaviour
{
    public MyType MyPieceType = MyType.Pawn;
    ChessPieceMovement myMovement = new Pawn();

    private void OnValidate()
    {
        switch (MyPieceType){
            case MyType.Pawn:
                myMovement = new Pawn();
                break;
            case MyType.Bishop:
                myMovement = new Bishop();
                break;
            case MyType.Knight:
                myMovement = new Knight();
                break;
            case MyType.Rook:
                myMovement = new Rook();
                break;
            case MyType.Queen:
                myMovement = new Queen();
                break;
            case MyType.King:
                myMovement = new King();
                break;
            default:
                break;
        }
    }
    private void OnDrawGizmosSelected()
    {
        myMovement.Movement(transform.position);
        myMovement.HandleShow(transform.position, MyPieceType);
    }
}

public abstract class ChessPieceMovement : Editor
{
    public abstract void Movement(Vector3 pos);
    public void HandleShow(Vector3 pos, MyType myPiece)
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(pos, Vector3.up, 1.0f);
        GUI.color = Color.black;
        Handles.Label(pos + new Vector3(.2f, 0, .7f), myPiece.ToString());
    }
}
public class Rook : ChessPieceMovement
{
    public override void Movement(Vector3 pos)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos + new Vector3(-7, 0, 0), pos + new Vector3(7, 0, 0));
        Gizmos.DrawLine(pos + new Vector3(0, 0, -7), pos + new Vector3(0, 0, 7));
    }
}
public class Pawn : ChessPieceMovement
{
    public override void Movement(Vector3 pos)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + new Vector3(1, 0, 1));
        Gizmos.DrawLine(pos, pos + new Vector3(-1, 0, 1));
        Gizmos.DrawLine(pos, pos + new Vector3(0, 0, 1));
    }
}
public class Bishop : ChessPieceMovement
{
    public override void Movement(Vector3 pos)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos + new Vector3(-7, 0, -7), pos + new Vector3(7, 0, 7));
        Gizmos.DrawLine(pos + new Vector3(7, 0, -7), pos + new Vector3(-7, 0, 7));
    }
}
public class Knight : ChessPieceMovement
{
    public override void Movement(Vector3 pos)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + new Vector3(0, 0, 1));
        Gizmos.DrawLine(pos + new Vector3(0, 0, 1), pos + new Vector3(2, 0, 1));

        Gizmos.DrawLine(pos, pos + new Vector3(0, 0, -1));
        Gizmos.DrawLine(pos + new Vector3(0, 0, -1), pos + new Vector3(2, 0, -1));

        Gizmos.DrawLine(pos, pos + new Vector3(0, 0, 1));
        Gizmos.DrawLine(pos + new Vector3(0, 0, 1), pos + new Vector3(-2, 0, 1));

        Gizmos.DrawLine(pos, pos + new Vector3(0, 0, -1));
        Gizmos.DrawLine(pos + new Vector3(0, 0, -1), pos + new Vector3(-2, 0, -1));

        Gizmos.DrawLine(pos, pos + new Vector3(1, 0, 0));
        Gizmos.DrawLine(pos + new Vector3(1, 0, 0), pos + new Vector3(1, 0, 2));

        Gizmos.DrawLine(pos, pos + new Vector3(-1, 0, 0));
        Gizmos.DrawLine(pos + new Vector3(-1, 0, 0), pos + new Vector3(-1, 0, -2));

        Gizmos.DrawLine(pos, pos + new Vector3(-1, 0, 0));
        Gizmos.DrawLine(pos + new Vector3(-1, 0, 0), pos + new Vector3(-1, 0, 2));

        Gizmos.DrawLine(pos, pos + new Vector3(1, 0, 0));
        Gizmos.DrawLine(pos + new Vector3(1, 0, 0), pos + new Vector3(1, 0, -2));

    }
}
public class Queen : ChessPieceMovement
{
    public override void Movement(Vector3 pos)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos + new Vector3(-7, 0, -7), pos + new Vector3(7, 0, 7));
        Gizmos.DrawLine(pos + new Vector3(7, 0, -7), pos + new Vector3(-7, 0, 7));
        Gizmos.DrawLine(pos + new Vector3(-7, 0, 0), pos + new Vector3(7, 0, 0));
        Gizmos.DrawLine(pos + new Vector3(0, 0, -7), pos + new Vector3(0, 0, 7));
    }
}
public class King : ChessPieceMovement
{
    public override void Movement(Vector3 pos)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos + new Vector3(-1, 0, -1), pos + new Vector3(1, 0, 1));
        Gizmos.DrawLine(pos + new Vector3(1, 0, -1), pos + new Vector3(-1, 0, 1));
        Gizmos.DrawLine(pos + new Vector3(-1, 0, 0), pos + new Vector3(1, 0, 0));
        Gizmos.DrawLine(pos + new Vector3(0, 0, -1), pos + new Vector3(0, 0, 1));
    }
}