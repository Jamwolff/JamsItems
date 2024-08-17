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
using PlayerRoles;
using System.Linq;
using Exiled.API.Features;
using Random = System.Random;

namespace Drugs
{
    [CustomItem(ItemType.Painkillers)]
    public class Pills : CustomItem
    {
        public override uint Id { get; set; } = 17;
        public override string Name { get; set; } = "Drugs, just straight up drugs";
        public override string Description { get; set; } = "When used, give a temporary speed and health boost, and then a quick crash";
        public override float Weight { get; set; } = 1.15f;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint()
                {
                    Chance = 5,
                    Location = SpawnLocationType.Inside079Secondary,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 5,
                    Location = SpawnLocationType.Inside049Armory,
                },
                new DynamicSpawnPoint()
                {
                    Chance= 5,
                    Location = SpawnLocationType.Inside330Chamber,
                }
            }
        };
        protected override void SubscribeEvents()
        {
            Player.UsingItem += OnUsingDrugs;

            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.UsingItem -= OnUsingDrugs;
            base.UnsubscribeEvents();
        }
        private void OnUsingDrugs(UsingItemEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;

            ev.Player.Health = 250f;
            ev.Player.EnableEffect(Exiled.API.Enums.EffectType.DamageReduction, 25f);
            ev.Player.EnableEffect(Exiled.API.Enums.EffectType.MovementBoost, 25f);
            ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Scp207, 25f);
            ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Invigorated, 25f);
            Timing.CallDelayed(25f, () => ev.Player.Health = 100f);
            Timing.CallDelayed(25f, () => ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Stained, 15f));
            Timing.CallDelayed(25f, () => ev.Player.EnableEffect(Exiled.API.Enums.EffectType.SinkHole, 15f));
            Timing.CallDelayed(25f, () => ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Traumatized, 15f));
            Timing.CallDelayed(25f, () => ev.Player.EnableEffect(Exiled.API.Enums.EffectType.InsufficientLighting, 15f));
        }
        //This is your sign to give up on your dreams
    }
}
