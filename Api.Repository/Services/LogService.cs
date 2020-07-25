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

        public Log Get(LogViewModel lvm)
        {
            var log = _context.Logs.Where(w => lvm.Description == w.Description && lvm.Level == w.Level).FirstOrDefault();

            return log;
        }

        public List<LogViewModel> GetAll()
        {
            //return _context.Logs.Where(w => w.Box == "primary").OrderBy(o => o.Id).ToList();
            var logs = _context.Logs.Where(w => w.Box == "primary");
            var logsGrouped = logs
                .GroupBy(g => new { Log = new { g.Level, g.Description }, Frequency = g.Level })
                .Select(s => new LogViewModel()
                {
                    Description = s.Key.Log.Description.Trim(),
                    Frequency = s.Count(),
                    Level = s.Key.Log.Level.Trim(),
                });

            var logsList = logsGrouped.ToList().OrderBy(o => o.Frequency).ToList();

            //Gambiarra
            var i = 1;
            foreach (var item in logsList)
            {

                item.Id = i;
                i++;
            }

            return logsList;
        }

        public List<LogViewModel> GetByBox(string box)
        {
            var logs = _context.Logs.Where(w => w.Box == box);
            var logsGrouped = logs.GroupBy(g => new { Log = g, Frequency = g.Level })
                .Select(s => new LogViewModel()
                {
                    //s.Key.Log.Origin.Trim(), s.Key.Log.Level.Trim(), s.Key.Log.Description.Trim(), s.Count(), s.Key.Log.Box.Trim()
                    Description = s.Key.Log.Description.Trim(),
                    Frequency = s.Count(),
                    Level = s.Key.Log.Level.Trim(),
                });

            //Gambiarra
            var i = 1;
            foreach (var item in logsGrouped)
            {

                item.Id = i;
                i++;
            }

            var logsList = logsGrouped.ToList();
            return logsList;
        }

        public List<Log> GetByFrequency(int frequency)
        {
            return _context.Logs.Where(w => w.Frequency == frequency).ToList();
        }

        public Log GetById(int id)
        {
            return _context.Logs.Find(id);
        }

        public List<LogViewModel> GetByLevel(string level)
        {
            var logs = _context.Logs.Where(w => w.Level == level)
                .Select(s => new LogViewModel
                {
                    Level = s.Level,
                    Description = s.Description,
                    Frequency = s.Frequency
                }).ToList();

            //Gambiarra
            var i = 1;
            foreach (var item in logs)
            {

                item.Id = i;
                i++;
            }

            return logs;
        }

        public List<LogViewModel> GetByOrigin(string origin)
        {
            var logs = _context.Logs.Where(w => w.Origin == origin)
                .Select(s => new LogViewModel
                {
                    Level = s.Level,
                    Description = s.Description,
                    Frequency = s.Frequency
                }).ToList();

            //Gambiarra
            var i = 1;
            foreach (var item in logs)
            {

                item.Id = i;
                i++;
            }

            return logs;
        }

        public string ToArchive(List<LogViewModel> logs)
        {

            foreach (var log in logs)
            {
                var task = Task.Run(() => _context.Logs.Where(w => w.Description == log.Description && log.Level == w.Level)
                    .ForEachAsync(f => f.Box = "archive"));

                task.Wait();

                _context.SaveChanges();
            }

            return "Archived log(s).";
        }

        public string ToPrimary(List<LogViewModel> logs)
        {
            foreach (var log in logs)
            {
                var task = Task.Run(() => _context.Logs.Where(w => w.Description == log.Description && log.Level == w.Level)
                    .ForEachAsync(f => f.Box = "primary"));

                task.Wait();

                _context.SaveChanges();
            }
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

        public string Delete(List<LogViewModel> logs)
        {

            foreach (var log in logs)
            {
                var list = _context.Logs.Where(w => log.Description == w.Description && log.Level == w.Level).ToList();
                _context.Logs.RemoveRange(list);
            }

            _context.SaveChanges();

            return "Log(s) Deleted.";
        }

        public List<LogViewModel> SearchFor(string env, string order, string search)
        {
            var logs = _context.Logs.Where(w => w.Origin == env);
            var logsSorted = order.ToLower() == "frequency" ? logs.OrderBy(o => o.Frequency) : logs.OrderBy(o => o.Level);
            var logsSearched = logsSorted.Where(w => w.Level.Contains(search) || w.Description.Contains(search) || w.Origin.Contains(search)).ToList();

            var logGrouped = logsSearched.GroupBy(g => new { g.Description, g.Frequency, g.Level });

            var logViewModel = logGrouped
            .Select(s => new LogViewModel()
            {
                Description = s.Key.Description,
                Frequency = s.Count(),
                Level = s.Key.Level,
            })
            .ToList();

            //Gambiarra
            var i = 1;
            foreach (var item in logViewModel)
            {

                item.Id = i;
                i++;
            }

            return logViewModel;
        }

    }
}
