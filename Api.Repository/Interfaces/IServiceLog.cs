using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces
{
    public interface IServiceLog
    {
        Log Get(LogViewModel lvm);
        Log GetById(int id);
        List<LogViewModel> GetAll();
        List<LogViewModel> GetByBox(string box);
        List<LogViewModel> GetByOrigin(string origin);
        List<LogViewModel> GetByLevel(string level);
        List<Log> GetByFrequency(int frequency);
        string ToArchive(List<LogViewModel> logs);
        string ToPrimary(List<LogViewModel> logs);
        string ToPrimaryAll();
        string Delete(List<LogViewModel> logs);
        List<LogViewModel> SearchFor(string env, string order, string search);

    }
}
