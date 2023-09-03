namespace Unit.Model
{
    public readonly struct DamageInfo
    {
        public readonly float Damage;
        public readonly string AttackName;

        public DamageInfo(float damage, string attackName)
        {
            Damage = damage;
            AttackName = attackName;
        }

        public static DamageInfo FromAttackModel(IAttackModel attackModel) =>
            new(attackModel.HitDamage, attackModel.Name);
    }
}