using System;
using System.Collections.Generic;
using System.Text;
using ZooCalculationBussinesLogic.BindingModels;
using ZooCalculationBussinesLogic.ViewModels;

namespace ZooCalculationBussinesLogic.Interfaces
{
   public interface IRouteLogic
    {
        List<RouteViewModel> Read(RouteBindingModel model);   
    }
}
