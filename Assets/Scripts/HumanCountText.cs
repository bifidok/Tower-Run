using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanCountText : MonoBehaviour
{
    [SerializeField] private Text _humanCount;

    public void UpdateText(int count)
    {
        _humanCount.text = "Human count: " + count;
    }
}
