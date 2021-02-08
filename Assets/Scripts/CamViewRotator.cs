using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamViewRotator : MonoBehaviour {

    public GameObject gameobject; // OculusGoの姿勢の参照用
    public Transform target; // 初期方向の参照用

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        // PlaneRotatorを初期方向に向かせる
        transform.LookAt(target);
        // OculusGoの姿勢にあわせてPlaneRotatorを回転させる
        var trans = gameobject.transform;
        transform.Rotate(trans.eulerAngles.x, trans.eulerAngles.y, 0.0f, Space.World); // 2軸のpan-tiltカメラ用
        // transform.Rotate(trans.eulerAngles.x, trans.eulerAngles.y, trans.eulerAngles.z, Space.World); // 3軸のpan-tilt-rollカメラ用
        // OculusGoの位置にあわせてPlaneRotatorを移動させる
        transform.position = trans.position;
    }
}