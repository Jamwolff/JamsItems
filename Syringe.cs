using System;
using System.Collections.Generic;
using Exiled.API;
using Exiled.CustomItems;
using Exiled.API.Features.Spawn;
using Exiled.Loader;
using InventorySystem.Items.Usables;
using Exiled.CustomItems.API.Features;
using Exiled.CustomItems.API.EventArgs;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Events;
using Exiled.API.Features.Attributes;
using PlayerStatsSystem;
using Exiled.API.Enums;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Map;
using UnityEngine;
using MEC;
using Player = Exiled.Events.Handlers.Player;
using Exiled.API.Interfaces;
using Exiled.API.Structs;
using Exiled.API.Extensions;
using CustomPlayerEffects;
using System.Linq;
using Exiled.API.Features;
using Random = System.Random;


namespace KYSyringe
{
    [CustomItem(ItemType.Adrenaline)]
    public class Syringe : CustomItem
    {
        public override uint Id { get; set; } = 42;
        public override string Name { get; set; } = "LJ-429";
        public override string Description { get; set; } = "When injected, the user has a quick death.";
        public override float Weight { get; set; } = 1.15f;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint()
                {
                    Chance = 100,
                    Location = SpawnLocationType.Inside096,
                }
            }
        };
        protected override void SubscribeEvents()
        {
            Player.UsingItem += OnUsingLJ;

            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.UsingItem -= OnUsingLJ;

            base.UnsubscribeEvents();
        }
        private void OnUsingLJ(UsingItemEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;

            ev.Player.Health = 1f;
            ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Poisoned, 500f);
            ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Bleeding, 500f);
            ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Corroding, 500f);
        }
    }
}
