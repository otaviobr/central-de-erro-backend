using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces
{
    public interface IServiceLog
    {
        Log GetById(int id);
        List<Log> GetAll();
        List<Log> GetByBox(string box);
        List<Log> GetByOrigin(string origin);
        List<Log> GetByLevel(string level);
        List<Log> GetByFrequency(int frequency);
        string ToArchive(List<Log> log);
        string ToPrimary(List<Log> log);
        string ToPrimaryAll();
        string Delete(List<Log> log);

    }
}
