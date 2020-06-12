using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooCalculationBussinesLogic.HelperModels
{
    class WordParagraphProperties
    {

        public string Size { get; set; }
        public bool Bold { get; set; }
        public JustificationValues JustificationValues { get; set; }
    }
}
