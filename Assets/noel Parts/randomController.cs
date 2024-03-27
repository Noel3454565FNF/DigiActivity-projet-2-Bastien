using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.Input;

public class randomController : MonoBehaviour
{
    public string[] inputLeftR;
    public string[] inputRightR;

    public KeyCode[] inputKey;

    public PLayerMovement PM;
    public List<KeyCode> KeyCodeLeft = new List<KeyCode>();
    // Start is called before the first frame update

    void Awake()
    {
        // Initialize KeyCodeLeft list with KeyCodes for A to Z
        KeyCodeLeft.AddRange(new KeyCode[]{
            KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H,
            KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P,
            KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
            KeyCode.Y, KeyCode.Z
        });
    }


    void Start()
    {
        int R1 = Random.RandomRange(0, 24);
        int R2 = Random.RandomRange(0, 24);

        PM.GettingReady(KeyCodeLeft[R1], KeyCodeLeft[R2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
