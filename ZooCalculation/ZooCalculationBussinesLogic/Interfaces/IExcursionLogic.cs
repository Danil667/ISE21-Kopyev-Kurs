using System;
using System.Collections.Generic;
using System.Text;
using ZooCalculationBussinesLogic.BindingModels;
using ZooCalculationBussinesLogic.ViewModels;

namespace ZooCalculationBussinesLogic.Interfaces
{
    public interface IExcursionLogic
    {
        List<ExcursionViewModel> Read(ExcursionBindingModel model);
        void CreateOrUpdate(ExcursionBindingModel model);
        void Delete(ExcursionBindingModel model);
    }
}
