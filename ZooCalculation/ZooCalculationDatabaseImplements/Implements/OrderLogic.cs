﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooCalculationBussinesLogic.BindingModels;
using ZooCalculationBussinesLogic.Interfaces;
using ZooCalculationBussinesLogic.ViewModels;
using ZooCalculationDatabaseImplements.Models;

namespace ZooCalculationDatabaseImplements.Implements
{
   public class OrderLogic:  IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new ZooCalculationDatabase())
            {
                Order elem = model.Id.HasValue ? null : new Order();
                if (model.Id.HasValue)
                {
                    elem = context.Orders.FirstOrDefault(rec => rec.Id ==
                       model.Id);
                    if (elem == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    elem = new Order();
                    context.Orders.Add(elem);
                }
                elem.ExcursionId = model.ExcursionId;
                elem.ClientId = model.ClientId;
                elem.Sum = model.Sum;
                elem.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new ZooCalculationDatabase())
            {
                Order elem = context.Orders.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (elem != null)
                {
                    context.Orders.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new ZooCalculationDatabase())
            {
                return context.Orders
                .Where(rec => model == null || rec.Id == model.Id || rec.ExcursionId.Equals(model.ExcursionId))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
					DateCreate = rec.DateCreate,
                    ExcursionId = rec.ExcursionId,
                    Sum = rec.Sum
                })
                .ToList();
            }
        }
    }
}