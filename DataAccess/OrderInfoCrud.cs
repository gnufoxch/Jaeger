using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Model;

namespace DataAccess
{
    public class OrderInfoCrud
    {
        public List<OrderInfo> GetCompleteList()
        {
            return Database.Singleton.OrderInfos.ToList();
        }

        public void InsertNow(OrderInfo order)
        {
            Database.Singleton.OrderInfos.Add(order);
            Database.Singleton.SaveChanges();
        }

        public void UpdateNow(OrderInfo order)
        {
            Database.Singleton.SaveChanges();
        }

        public void DeleteNow(OrderInfo order)
        {
            Database.Singleton.OrderInfos.Remove(order);
            Database.Singleton.SaveChanges();
        }
    }
}
