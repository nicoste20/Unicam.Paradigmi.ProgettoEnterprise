﻿using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services;

public interface IPresenzaService
{
    Task AddPresenzaAsync(Presenza presenza);
    Task DeleteAsync(int idPresenza);

    public Task<(List<Presenza>, int)> Search(string courseName, string studentSurname = null,
        string lecturerSurname = null,
        DateTime? lessonDate = null, int page = 1, int pageSize = 10);
}