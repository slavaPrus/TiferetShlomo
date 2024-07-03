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
                    existingFlyer.ParashatShavuaDescribe = flyer.ParashatShavuaDescribe;


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
        public async Task<(List<Flyer>, bool)> GetFlyersByPage(int skipCount, int pageSize)
        {
            try
            {
                // Use your DbContext to query the database for books based on skipCount and pageSize
                List<Flyer> flyers = await _context.Flyers
                    .OrderBy(flyer => flyer.FlyerId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
                int totalCount = await _context.Flyers
                .CountAsync();

                // Calculate if there are more books available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (flyers, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetFlyersByPage in FlyerDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }
        public async Task<(List<Flyer>, bool)> GetSearchFlyersByPage(int skipCount, int pageSize, string str)
        {
            try
            {
                // Use your DbContext to query the database for books based on skipCount and pageSize
                List<Flyer> flyers = await _context.Flyers
                    .Where(flyer => flyer.ParashatShavuaDescribe.Contains(str)) // search for books based on the bookname property
                    .OrderBy(flyer => flyer.FlyerId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
                int totalCount = await _context.Flyers
                   .Where(flyer => flyer.ParashatShavuaDescribe.Contains(str))
                   .CountAsync();

                // Calculate if there are more books available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (flyers, hasNext);

          
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetSearchFlyersByPage in FlyerDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }
        public async Task<(List<Flyer>, bool)> GetFilterFlyersByPage(int skipCount, int pageSize, string str)
        {
            try
            {
                // Retrieve filtered books from the repository based on category and pagination parameters
                List<Flyer> books = await _context.Flyers
                    .Where(flyer => flyer.ParashatShavua.Describe == str) // Filter books based on category
                    .OrderBy(flye => flye.FlyerId) // or any other property you want to order by
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();

                // Calculate total count of books for the given filter criteria
                int totalCount = await _context.Flyers
                    .Where(flyer => flyer.ParashatShavua.Describe == str)
                    .CountAsync();

                // Calculate if there are more books available based on pagination parameters and total count
                bool hasNext = skipCount + pageSize < totalCount;

                return (books, hasNext);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them as needed
                Console.Write(ex.ToString(), "GetFilterFlyersByPage in FlyerDAL");
                return (null, false); // Propagate the exception to the BL layer for centralized error handling
            }
        }

    }
}


