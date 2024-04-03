﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
    // repository per l'entità lezione
    public class LezioneRepository : GenericRepository<Lezione>
    {
        public LezioneRepository(MyDbContext ctx) : base(ctx)
        {
        }
    }
}
