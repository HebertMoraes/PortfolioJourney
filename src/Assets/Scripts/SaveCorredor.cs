using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveCorredor
{
    public static List<Vector3> posCorredores = new List<Vector3>();
    public static List<Quaternion> rotationCorredores = new List<Quaternion>();
    public static List<Vector3> posDoors = new List<Vector3>();
    public static List<Quaternion> rotationDoors = new List<Quaternion>();
    public static List<Vector3> posObjFlutuantes = new List<Vector3>();
    public static List<Quaternion> rotationObjFlutuantes = new List<Quaternion>();
    //está sendo salva mas não usado (load), talvez nem use
    //public static List<Rigidbody> rigdObjFlutuantes = new List<Rigidbody>();
    public static Vector3 posJogador;
    public static Quaternion rotationJogador;
    public static bool possuiSave;
}
