using System;
using System.Collections.Generic;
using DataAccess;
using Order.Model;

namespace Business
{
    public class OrderInfoLogic
    {
        private readonly OrderInfoCrud _crud = new OrderInfoCrud();

        public List<OrderInfo> GetCompleteList()
        {
            return _crud.GetCompleteList();
        }

        public void Insert(OrderInfo order)
        {
            Validate(order);

            _crud.InsertNow(order);
        }
        public void Update(OrderInfo order)
        {
            Validate(order);

            _crud.UpdateNow(order);
        }
        public void Delete(OrderInfo order)
        {
            if (order == null)
            {
                throw new ValidationException("No order selected to delete!");
            }

            _crud.DeleteNow(order);
        }

        private void Validate(OrderInfo order)
        {
            if (string.IsNullOrWhiteSpace(order.XmlContent))
            {
                throw new ValidationException("There is no xml content! Xml must be included");
            }
        }
    }
}
