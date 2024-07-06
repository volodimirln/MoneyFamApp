using iTextSharp.text.pdf;
using iTextSharp.text;
using MoneyFamDestopApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyFamDestopApp.UI.Windows;

namespace MoneyFamDestopApp.Services
{
    public class PrintStatistics
    {
        public static bool PrintStatisticsFile(int userId)
        {

            Document document = new Document();
            BaseFont baseFont = BaseFont.CreateFont("Resources\\Fonts\\Montserrat-Black.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont base1 = BaseFont.CreateFont("Resources\\Fonts\\Montserrat-SemiBold.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont base2 = BaseFont.CreateFont("Resources\\Fonts\\Montserrat-Medium.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 35f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 14f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font2 = new iTextSharp.text.Font(base2, 14f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font3 = new iTextSharp.text.Font(base1, 16f, iTextSharp.text.Font.NORMAL);
            String time = DateTime.Now.ToString("dd.MM.yyyy HH.mm");
            using (FileStream stream = new FileStream(@"Statistics(" + time + ").pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                String phrase = "Статистика от " + DateTime.Now.ToString("dd.MM.yyyy HH.mm");
                User user = Model.GetContex().Users.FirstOrDefault(p => p.Id == userId);
                int paymentcount = Model.GetContex().Payments.Where(p => p.Goal.User.Id == userId && p.IsDone == false).Count();
                int amount = 0;
                try
                {
                    amount = Model.GetContex().Operations.Where(p => p.UserId == userId).Sum(p => p.Amount);
                }
                catch 
                {
                    return false;
                }
                int target = Model.GetContex().Goals.Where(p => p.UserId == userId).Count();
                document.Add(new iTextSharp.text.Paragraph(phrase, font1));
                document.Add(new iTextSharp.text.Paragraph("Данные клиента", font3));
                document.Add(new iTextSharp.text.Paragraph(user.Surname + " " + user.Name + " " + user.Patronymic, font2));
                document.Add(new iTextSharp.text.Paragraph(user.Login, font2));
                document.Add(new iTextSharp.text.Paragraph("Количество операций: " + paymentcount, font2));
                document.Add(new iTextSharp.text.Paragraph("Общие траты: " + amount + "₽", font2));
                document.Add(new iTextSharp.text.Paragraph("Действующие цели: " + target, font2));

                document.Close();
                Process.Start(@"Statistics(" + time + ").pdf");
                return true;
            }
        }
    }
}
