namespace SymbolAnalysis.Creatures
{
    public interface ICreature
    {
        long UniqueId { get; }
        sbyte[] DnaBytes { get; }       //The DNA
        float Success { get; }         //How successful the creature is untill now
        int StepIntervalMs { get; }    //Time to wait between searches
        uint Age { get;  }
        bool IsAlive { get; }               //Is the creature alive

        float Search();                     //Explore one step in the world
        void Start();                       //Start living
        void Kill();                        //Stop living
        ICreature Evolve();                 //Evolve to a new mutated creature
        bool IsEvolveCondition();           //Is the creature mature enough and successful enough to evolve
        bool IsDieCondition();              //Is the creature too old, stuck or not successful enough so it should die
    }
}