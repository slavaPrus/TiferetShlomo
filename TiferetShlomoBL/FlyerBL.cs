﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiferetShlomoDAL.Models;
using TiferetShlomoDAL;
using AutoMapper;

namespace TiferetShlomoBL
{
    public class FlyerBL : IFlyerBL
    {
        private readonly IFlyerDAL _flyerDAL; // Inject IFlyerDAL interface here
        private readonly IMapper _mapper;

        public FlyerBL(IFlyerDAL flyerDAL,IMapper mapper)
        {
            _flyerDAL = flyerDAL;
            _mapper = mapper;
        }

        public IEnumerable<Flyer> GetAllFlyers()
        {
            try
            {
                return _flyerDAL.GetAllFlyers();
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
                return _flyerDAL.GetFlyerById(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void AddFlyer(Flyer flyer)
        {
            try
            {
                _flyerDAL.AddFlyer(flyer);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void UpdateFlyer(Flyer flyer)
        {
            try
            {
                _flyerDAL.UpdateFlyer(flyer);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

        public void RemoveFlyer(int id)
        {
            try
            {
                _flyerDAL.RemoveFlyer(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }
    }
}
