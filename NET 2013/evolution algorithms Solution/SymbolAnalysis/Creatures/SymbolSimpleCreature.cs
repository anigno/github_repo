namespace SymbolAnalysis.Creatures
{
    public class SymbolSimpleCreature : CreatureBase
    {
        private readonly SymbolSimpleWorld m_symbolSimpleWorld;

        public SymbolSimpleCreature(sbyte[] p_dnaBytes,SymbolSimpleWorld p_symbolSimpleWorld)
            : base(p_dnaBytes)
        {
            m_symbolSimpleWorld = p_symbolSimpleWorld;
        }

        public override ICreature Evolve()
        {
            sbyte[] newDna = DuplicateDna();
            int i = RandomGenerator.Next(0, newDna.Length);
            sbyte delta = RandomGenerator.NextPlusMinus();
            newDna[i] += delta;

            SymbolSimpleCreature newCreature = new SymbolSimpleCreature(newDna,m_symbolSimpleWorld);
            return newCreature;
        }

        public override bool IsEvolveCondition()
        {
            return false;
        }

        //DNA
        //

        public override float Search()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsDieCondition()
        {
            return false;
        }
    }
}