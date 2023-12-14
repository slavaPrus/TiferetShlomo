using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class JoiningDAL : IJoiningDAL
    {
        private readonly TIFERET_SHLOMOContext _context;

        public JoiningDAL(TIFERET_SHLOMOContext context)
        {
            _context = context;
        }

        public IEnumerable<Joining> GetAllJoinings()
        {
            try
            {
                return _context.Joinings
                    .Include(j => j.Category)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public Joining GetJoiningById(int id)
        {
            try
            {
                return _context.Joinings
                    .Include(j => j.Category)
                    .FirstOrDefault(j => j.JoinId == id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void AddJoining(Joining joining)
        {
            try
            {
                _context.Joinings.Add(joining);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void UpdateJoining(Joining joining)
        {
            try
            {
                _context.Entry(joining).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void RemoveJoining(int id)
        {
            try
            {
                var joining = _context.Joinings.Find(id);
                if (joining != null)
                {
                    _context.Joinings.Remove(joining);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }
    }
}
    