using Api.Repository.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.Services
{
    public class LogService : IServiceLog
    {
        private readonly ApiContext _context;

        public LogService(ApiContext context)
        {
            _context = context;
        }

        public List<Log> GetAll()
        {
            return _context.Logs.Where(w => w.Box == "primary").OrderBy(o => o.Id).ToList();
        }

        public List<Log> GetByBox(string box)
        {
            return _context.Logs.Where(w => w.Box == box).ToList();
        }

        public List<Log> GetByFrequency(int frequency)
        {
            return _context.Logs.Where(w => w.Frequency == frequency).ToList();
        }

        public Log GetById(int id)
        {
            return _context.Logs.Find(id);
        }

        public List<Log> GetByLevel(string level)
        {
            return _context.Logs.Where(w => w.Level == level).ToList();
        }

        public List<Log> GetByOrigin(string origin)
        {
            return _context.Logs.Where(w => w.Origin == origin).ToList();
        }

        public string ToArchive(List<Log> log)
        {
            log.ForEach(f => _context.Logs.Find(f.Id).Box = "archive");
            _context.SaveChanges();
            return "Archived log(s).";
        }

        public string ToPrimary(List<Log> log)
        {
            log.ForEach(f => _context.Logs.Find(f.Id).Box = "primary");
            _context.SaveChanges();
            return "Unarchived log(s).";
        }
        public string ToPrimaryAll()
        {
            string response;
            try
            {
                var t = Task.Run(() => _context.Logs.ForEachAsync(f => f.Box = "primary"));
                t.Wait();
                _context.SaveChanges();
                response = "All logs have been moved to the primary.";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

        public string Delete(List<Log> log)
        {
            log.ForEach(f => _context.Logs.Remove(f));
            _context.SaveChanges();
            return "Message(s) Deleted.";
        }

    }
}
