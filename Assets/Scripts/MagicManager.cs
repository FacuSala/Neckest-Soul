using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    public int maxMagic;
    public int currentMagic;
    // Start is called before the first frame update
    void Start(){
       currentMagic = maxMagic;
    }
    public void UseMagic (int mp){
        if (currentMagic >= mp)
        {
            currentMagic -= mp;
        }
    }
}
