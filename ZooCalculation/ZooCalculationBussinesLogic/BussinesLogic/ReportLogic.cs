using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using ZooCalculationBussinesLogic.BindingModels;
using ZooCalculationBussinesLogic.HelperModels;
using ZooCalculationBussinesLogic.Interfaces;
using ZooCalculationBussinesLogic.ViewModels;

namespace ZooCalculationBussinesLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IRouteLogic routeLogic;
        private readonly IExcursionLogic edLogic;
        private readonly IOrderLogic payLogic;
        public ReportLogic(IRouteLogic routeLogic, IExcursionLogic edLogic, IOrderLogic payLogic)
        {
            this.routeLogic = routeLogic;
            this.edLogic = edLogic;
            this.payLogic = payLogic;
        }
        public List<RouteViewModel> GetRouteForExcursions(ExcursionViewModel ed)
        {
            var routes = new List<RouteViewModel>();

            foreach (var route in ed.RouteForExcursions)
            {
                routes.Add(routeLogic.Read(new RouteBindingModel
                {
                    Id = route.RouteId
                }).FirstOrDefault());

            }
            return routes;
        }
        public Dictionary<int, List<OrderViewModel>> GetExcursionOrders(ExcursionBindingModel model)
        {
            var excursions = edLogic.Read(model).ToList();
            Dictionary<int, List<OrderViewModel>> pays = new Dictionary<int, List<OrderViewModel>>();
            foreach (var excursion in excursions)
            {
                var EdOrders = payLogic.Read(new OrderBindingModel { ExcursionId = excursion.Id }).ToList();
                pays.Add(excursion.Id, EdOrders);
            }
            return pays;
        }
        public void SaveExcursionOrdersToPdfFile(string fileName, ExcursionBindingModel excursion, string email)
        {
            string title = "Список маршрутов по экскурсиям";
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = fileName,
                Title = title,
                Excursions = edLogic.Read(excursion).ToList(),
                Orders = GetExcursionOrders(excursion)
            });
            SendMail(email, fileName, title);
        }
        public void SaveRouteForExcursionsToWordFile(string fileName, ExcursionViewModel excursion, string email)
        {
            string title = "Список маршрутов ";
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                Routes = GetRouteForExcursions(excursion)
            });
            SendMail(email, fileName, title);
        }
        public void SaveRouteForExcursionsToExcelFile(string fileName, ExcursionViewModel excursion, string email)
        {
            string title = "Список маршрутов ";
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = fileName,
                Title = title,
                Routes = GetRouteForExcursions(excursion)
            });
            SendMail(email, fileName, title);
        }
        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("kopev2000@mail.ru", "Зоопарк»");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("kopev2000@mail.ru", "687863dan");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}