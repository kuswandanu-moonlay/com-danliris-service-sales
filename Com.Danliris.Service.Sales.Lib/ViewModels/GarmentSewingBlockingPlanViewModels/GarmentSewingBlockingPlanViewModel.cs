﻿using Com.Danliris.Service.Sales.Lib.Utilities;
using Com.Danliris.Service.Sales.Lib.ViewModels.IntegrationViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.ViewModels.GarmentSewingBlockingPlanViewModels
{
    public class GarmentSewingBlockingPlanViewModel : BaseViewModel, IValidatableObject
    {
        public long BookingOrderId { get; set; }
        public string BookingOrderNo { get; set; }
        public DateTimeOffset BookingOrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public BuyerViewModel Buyer { get; set; }
        public double OrderQuantity { get; set; }
        public string Remark { get; set; }
        public string BookingItems { get; set; }

        public List<GarmentSewingBlockingPlanItemViewModel> Items { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(BookingOrderNo))
            {
                yield return new ValidationResult("Kode Booking MD tidak boleh kosong", new List<string> { "BookingOrderNo" });
            }
            if(Items==null || Items.Count == 0)
            {
                yield return new ValidationResult("Detail tidak boleh kosong", new List<string> { "details" });
            }
            else
            {
                int Count = 0;
                string ItemError = "[";

                foreach (GarmentSewingBlockingPlanItemViewModel item in Items)
                {
                    ItemError += "{";
                    if (item.Comodity==null)
                    {
                        Count++;
                        ItemError += " Comodity: 'Komoditas harus diisi' , ";
                    }

                    if (item.OrderQuantity <= 0)
                    {
                        Count++;
                        ItemError += " OrderQuantity: 'Jumlah tidak boleh kurang dari 0' , ";
                    }

                    if (item.DeliveryDate == DateTimeOffset.MinValue || item.DeliveryDate == null)
                    {
                        Count++;
                        ItemError += " DeliveryDate: 'Tanggal Pengiriman Harus Diisi' , ";
                    }
                    else if (item.DeliveryDate > this.DeliveryDate)
                    {
                        Count++;
                        ItemError += " DeliveryDate: 'Tanggal Pengiriman Harus Kurang dari Booking Tanggal Pengiriman' , ";
                    }
                    else if (item.DeliveryDate <= this.BookingOrderDate)
                    {
                        Count++;
                        ItemError += " DeliveryDate: 'Tanggal Pengiriman Harus Lebih dari Tanggal Booking' , ";
                    }
                    ItemError += "}, ";
                }

                ItemError += "]";

                if (Count > 0)
                {
                    yield return new ValidationResult(ItemError, new List<string> { "Items" });
                }
            }
        }
    }
}
