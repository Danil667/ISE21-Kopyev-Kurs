using System;
using System.Collections.Generic;
using System.Text;
using ZooCalculationBussinesLogic.ViewModels;

namespace ZooCalculationBussinesLogic.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ExcursionViewModel> Excursions { get; set; }
        public Dictionary<int, List<OrderViewModel>> Orders { get; set; }
    }
}
