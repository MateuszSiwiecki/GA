using System.Collections.Generic;

namespace GALib
{
    public interface ISelection
    {
        List<Chromosome> DrawChromosomes(List<Chromosome> listOfChromosomes);
    }
}