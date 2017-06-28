﻿using UnityEngine;
using System.Collections;
using System;

public class PokemonHelper : MonoBehaviour
{
    public PokemonModel MyPokemonModel { get; set; }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public void LoadPokemon(PokemonModel item)
    {
        MyPokemonModel = item;
    }
}
