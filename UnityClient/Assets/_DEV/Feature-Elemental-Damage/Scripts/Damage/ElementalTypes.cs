namespace ElementalDamage
{
    public enum EElementalCombination
    {
        None,
        Explosion,
        Overcharge,
        Melt,
        Crushed,
        Grounded,
        Rooted,
        Frozen
    }

    public enum EElementalType
    {
        Physical,
        Fire,
        Ice,
        Earth,
        Lightning,
        Nature
    }

    public abstract class Element
    {
        public abstract EElementalType GetElementalType();
        public override abstract string ToString();
        
        public abstract EElementalCombination GetCombination(Element element);
        public abstract EElementalCombination GetCombination(EElementalType element);
    }

    public class Physical : Element
    {
        public override EElementalType GetElementalType() => EElementalType.Physical;
        public override string ToString() => "Physical";
        public override EElementalCombination GetCombination(Element element) => GetCombination(element.GetElementalType());
        public override EElementalCombination GetCombination(EElementalType element) => element switch
        {
            _ => EElementalCombination.None
        };
    }

    public class Fire : Element
    {
        public override EElementalType GetElementalType() => EElementalType.Fire;
        public override string ToString() => "Fire";
        public override EElementalCombination GetCombination(Element element) => GetCombination(element.GetElementalType());
        public override EElementalCombination GetCombination(EElementalType element) => element switch
        {
            EElementalType.Ice => EElementalCombination.Melt,
            EElementalType.Lightning => EElementalCombination.Overcharge,
            EElementalType.Nature => EElementalCombination.Explosion,
            EElementalType.Earth => EElementalCombination.Explosion,
            _ => EElementalCombination.None
        };
    }

    public class Ice : Element
    {
        public override EElementalType GetElementalType() => EElementalType.Ice;
        public override string ToString() => "Ice";
        public override EElementalCombination GetCombination(Element element) => GetCombination(element.GetElementalType());
        public override EElementalCombination GetCombination(EElementalType element) => element switch
        {
            EElementalType.Nature => EElementalCombination.Frozen,
            EElementalType.Fire => EElementalCombination.Melt,
            EElementalType.Lightning => EElementalCombination.Overcharge,
            EElementalType.Earth => EElementalCombination.Crushed,
            _ => EElementalCombination.None
        };
    }

    public class Earth : Element
    {
        public override EElementalType GetElementalType() => EElementalType.Earth;
        public override string ToString() => "Earth";
        public override EElementalCombination GetCombination(Element element) => GetCombination(element.GetElementalType());
        public override EElementalCombination GetCombination(EElementalType element) => element switch
        {
            EElementalType.Ice => EElementalCombination.Crushed,
            EElementalType.Nature => EElementalCombination.Rooted,
            EElementalType.Lightning => EElementalCombination.Grounded,
            EElementalType.Fire => EElementalCombination.Explosion,
            _ => EElementalCombination.None
        };
    }

    public class Lightning : Element
    {
        public override EElementalType GetElementalType() => EElementalType.Lightning;
        public override string ToString() => "Lightning";
        public override EElementalCombination GetCombination(Element element) => GetCombination(element.GetElementalType());
        public override EElementalCombination GetCombination(EElementalType element) => element switch
        {
            EElementalType.Ice => EElementalCombination.Overcharge,
            EElementalType.Fire => EElementalCombination.Overcharge,
            EElementalType.Earth => EElementalCombination.Grounded,
            _ => EElementalCombination.None
        };
    }

    public class Nature : Element
    {
        public override EElementalType GetElementalType() => EElementalType.Nature;
        public override string ToString() => "Nature";
        public override EElementalCombination GetCombination(Element element) => GetCombination(element.GetElementalType());
        public override EElementalCombination GetCombination(EElementalType element) => element switch
        {
            EElementalType.Earth => EElementalCombination.Rooted,
            EElementalType.Ice => EElementalCombination.Frozen,
            EElementalType.Fire => EElementalCombination.Explosion,
            _ => EElementalCombination.None
        };
    }
}