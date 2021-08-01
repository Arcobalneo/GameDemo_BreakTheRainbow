using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : Singleton<PlayerEnergy>
{
    [SerializeField] EnergyBar energyBar;
    public const int MAX_ENERGY = 100;
    public const int MAX_PERCENT = 1;

    int curEnergy;

    private void Start()
    {
        energyBar.Init(curEnergy, MAX_ENERGY);
    }

    public void ObtainEnergy(int val)
    {
        if (curEnergy == MAX_ENERGY) return;

        curEnergy = Mathf.Clamp(curEnergy + val, 0, MAX_ENERGY);
        energyBar.UpdateState(curEnergy, MAX_ENERGY);
    }

    public void UseEnergy(int val)
    {
        curEnergy = Mathf.Clamp(curEnergy - val, 0, MAX_ENERGY);
        energyBar.UpdateState(curEnergy, MAX_ENERGY);
    }

    public bool IsEnough(int val) => curEnergy >= val;
}
