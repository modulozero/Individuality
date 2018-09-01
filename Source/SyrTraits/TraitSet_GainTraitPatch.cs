﻿using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using RimWorld;
using Verse;
using UnityEngine;

namespace SyrTraits
{
    [HarmonyPatch(typeof(TraitSet), "GainTrait")]
    public static class TraitSet_GainTraitPatch
    {
        [HarmonyPostfix]
        public static void TraitSet_GainTrait_Postfix(Trait trait, TraitSet __instance)
        {
            Pawn pawn = Traverse.Create(__instance).Field("pawn").GetValue<Pawn>();
            if (trait.def == TraitDefOf.Gay || trait.def == TraitDefOf.PsychicSensitivity)
            {
                __instance.allTraits.Remove(trait);
            }
        }
    }
}
