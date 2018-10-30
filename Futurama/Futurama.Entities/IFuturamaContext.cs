﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Futurama.Entities
{
    public interface IFuturamaContext : IDisposable
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<Character> Characters { get; set; }
        DbSet<EpisodeCharacter> EpisodeCharacters { get; set; }
        DbSet<Episode> Episodes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}