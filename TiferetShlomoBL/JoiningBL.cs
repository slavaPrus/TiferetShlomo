using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;

namespace TiferetShlomoBL
{
    public class JoiningBL : IJoiningBL
    {
        private readonly IJoiningDAL _joiningDAL; // Inject JoiningDAL interface here

        public JoiningBL(IJoiningDAL joiningDAL)
        {
            _joiningDAL = joiningDAL;
        }

        public IEnumerable<Joining> GetAllJoinings()
        {
            try
            {
                return _joiningDAL.GetAllJoinings();
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
                return _joiningDAL.GetJoiningById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddJoining(Joining joining)
        {
            try
            {
                _joiningDAL.AddJoining(joining);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateJoining(Joining joining)
        {
            try
            {
                _joiningDAL.UpdateJoining(joining);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveJoining(int id)
        {
            try
            {
                _joiningDAL.RemoveJoining(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
