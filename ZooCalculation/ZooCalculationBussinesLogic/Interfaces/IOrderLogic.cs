using System;
using System.Collections.Generic;
using System.Text;
using ZooCalculationBussinesLogic.BindingModels;
using ZooCalculationBussinesLogic.ViewModels;

namespace ZooCalculationBussinesLogic.Interfaces
{
   public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
