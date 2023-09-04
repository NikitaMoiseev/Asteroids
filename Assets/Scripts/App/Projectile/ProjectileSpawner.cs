using App.CommonUnit.Config;
using App.CommonUnit.Config.Attack;
using App.CommonUnit.Model;
using App.Enemy.Config;
using App.Enemy.Model;
using App.Player.Config;
using App.Player.Model;
using ObjectFactory;
using Projectile.Model;
using System;
using System.Collections.Generic;
using Unit.Model;
using UnityEngine;

namespace App.Enemy.Manager
{
    public class ProjectileSpawner
    {
        private IObjectFactory _objectFactory;

        public ProjectileSpawner(IObjectFactory factory)
        {
            _objectFactory = factory;
        }

        public Projectile.Projectile SpawnProjectile(string id, DamageInfo damageInfo, Vector3 direction, Transform launchTransform)
        {
            var projectile = _objectFactory.Create<Projectile.Projectile>(id);
            var projectileModel = new ProjectileModel(damageInfo, direction);
            projectile.Init(projectileModel);
            projectile.transform.SetPositionAndRotation(launchTransform.position, launchTransform.rotation);
            return projectile;
        }
    }
}