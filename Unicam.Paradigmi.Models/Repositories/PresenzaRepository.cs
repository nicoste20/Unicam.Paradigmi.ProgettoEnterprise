using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories;

public class PresenzaRepository : GenericRepository<Presenza>
{

    public PresenzaRepository(MyDbContext ctx) : base(ctx)
    {
    }

}