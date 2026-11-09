using InnManager.Billing;
using InnManager.Hotels;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace InnManager.WpfApp.ViewModels
{
    public class ReceiptViewModel
    {
        public ReceiptViewModel(Hotel h, Payment p) {
            _hotel = h;
            _payment = p;

        }
        private Payment _payment;
        private Hotel _hotel;
        public string PaymentReference { get => _payment.PaymentReference; }
        public string InvoiceNumber { get => _payment.Invoice.InvoiceID; }
        public string PaymentDate { get => (_payment.Date).ToString(); }
        public string Guest { get => _payment.GuestName; }
        public string Room { get => _payment.Invoice.RoomNumber; }
        public decimal InvoiceTotal { get => _payment.Invoice.TotalCharges; }
        public decimal AmountPaid { get => _payment.Amount; }
        public decimal RemainingBalance { get => _payment.Invoice.BalanceDue; }
        public string PaymentMethod { get => (_payment.PaymentMethod).ToString(); }
        public string Status { get => _payment.Invoice.Status; }
        public void Generate() {
            string filepath = ($"receipt_{PaymentReference}_{_payment.Date:yyyy-MM-dd_HH-mm-ss}.html");
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset='UTF-8'>");
            sb.Append($"<title>{_hotel.Name} Receipt</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>{_hotel.Name}</h1>");
            sb.Append($"<h1>PAYMENT RECEIPT</h1>");
            sb.Append($"<p>Payment Reference: {PaymentReference}</p>");
            sb.Append($"<p>Invoice Number: {InvoiceNumber}</p>");
            sb.Append($"<p>Guest: {Guest}</p>");
            sb.Append($"<p>Room: {Room}</p>");
            sb.Append($"<p>Payment Date: {PaymentDate}</p>");
            sb.Append($"<p>Payment Method: {PaymentMethod}</p>");
            sb.Append($"<p>Invoice Total: {InvoiceTotal:C}</p>");
            sb.Append($"<p>Amount Paid: {AmountPaid:C}</p>");
            sb.Append($"<p>Remaining Balance: {RemainingBalance:C}</p>");
            sb.Append($"<p>Status: {Status}</p>");
            sb.Append("</body>");
            sb.Append("</html>");
            string content = sb.ToString();
            try
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Receipt generated");
            }
            catch (Exception ex){
                MessageBox.Show($"There was an error in generating your receipt.{ex.Message}");
            }
        }
    }
}
