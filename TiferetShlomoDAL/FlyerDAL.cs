using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class FlyerDAL : IFlyerDAL
    {
        private readonly TIFERET_SHLOMOContext _context;

        public FlyerDAL(TIFERET_SHLOMOContext context)
        {
            _context = context;
        }

        public IEnumerable<Flyer> GetAllFlyers()
        {
            try
            {
                return _context.Flyers.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public Flyer GetFlyerById(int id)
        {
            try
            {
                return _context.Flyers.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddFlyer(Flyer flyer)
        {
            try
            {
                _context.Flyers.Add(flyer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFlyer(Flyer flyer)
        {
            try
            {
                _context.Entry(flyer).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveFlyer(int id)
        {
            try
            {
                var flyer = _context.Flyers.Find(id);
                if (flyer != null)
                {
                    _context.Flyers.Remove(flyer);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
