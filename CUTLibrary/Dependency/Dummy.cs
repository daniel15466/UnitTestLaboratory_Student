using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUT
{
    public class Money
    {
        public Money(decimal price)
        { }
    }
    public class Product
    {
        public Product(string name, Money unitPrice)
        {
        }
    }

    public class Item : IItem
    {
        private Product _product;
        private double _quantity;
        public Item(Product p, double q)
        {
            this._product = p;
            this._quantity = q;
        }

        public double GetQuantity()
        {
            return this._quantity;
        }
    }

    public interface IItem
    {
        double GetQuantity();
    }

    public class Invoice
    {
        private List<IItem> _itemList = new List<IItem>();

        public void Add(IItem item)
        {
            this._itemList.Add(item);
        }

        public long GetCount()
        {
            return this._itemList.Count;
        }
    }
}
