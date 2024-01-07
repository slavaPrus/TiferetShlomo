using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Flyer>> GetAllFlyers()
        {
            try
            {
                return await _context.Flyers.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetAllFlyers DAL");
                return null;
            }
        }

        public async Task<Flyer> GetFlyerById(int id)
        {
            try
            {
                return await _context.Flyers.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "GetFlyerById DAL");
                return null;
            }
        }

        public async Task<List<Flyer>> AddFlyer(Flyer flyer)
        {
            try
            {
                await _context.Flyers.AddAsync(flyer);
                await _context.SaveChangesAsync();
                return await GetAllFlyers();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "AddFlyer DAL");
                return null;
            }
        }

        public async Task<Flyer> UpdateFlyer(Flyer flyer)
        {
            try
            {
                Flyer existingFlyer = await _context.Flyers.FirstOrDefaultAsync(x => x.FlyerId == flyer.FlyerId);
                if (existingFlyer != null)
                {
                    existingFlyer.PublishDate = flyer.PublishDate;
                    existingFlyer.ParashatShavuaId = flyer.ParashatShavuaId;
                    existingFlyer.FlyerUrl = flyer.FlyerUrl;
                    existingFlyer.FlyerData = flyer.FlyerData;
                    existingFlyer.PictureUrl = flyer.PictureUrl;
                    existingFlyer.PictureId = flyer.PictureId;

                    await _context.SaveChangesAsync();
                }
                return existingFlyer;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "UpdateFlyer DAL");
                return null;
            }
        }

        public async Task RemoveFlyer(int id)
        {
            try
            {
                Flyer flyer = await _context.Flyers.FindAsync(id);
                if (flyer != null)
                {
                    _context.Flyers.Remove(flyer);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString(), "RemoveFlyer DAL");
            }
        }
    }
}
