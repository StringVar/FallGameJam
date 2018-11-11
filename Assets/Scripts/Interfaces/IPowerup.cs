﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerup {
    void Effect();
    void OnTriggerEnter2D(Collider2D collision);
}
