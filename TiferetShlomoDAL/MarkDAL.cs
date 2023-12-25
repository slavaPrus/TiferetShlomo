using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;

namespace TiferetShlomoDAL
{
    public class MarkDAL : IMarkDAL
    {
        private readonly TIFERET_SHLOMOContext _context;
      

        public MarkDAL(TIFERET_SHLOMOContext context)
        {
            _context = context;
        }

        public IEnumerable<Mark> GetAllMarks()
        {
            return _context.Marks.ToList();
        }

        public Mark GetMarkById(int id)
        {
            return _context.Marks.Find(id);
        }

        public void AddMark(Mark mark)
        {
            _context.Marks.Add(mark);
            _context.SaveChanges();
        }

        public void UpdateMark(Mark mark)
        {
            _context.Entry(mark).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveMark(int id)
        {
            var mark = _context.Marks.Find(id);
            if (mark != null)
            {
                _context.Marks.Remove(mark);
                _context.SaveChanges();
            }
        }
    }
}
