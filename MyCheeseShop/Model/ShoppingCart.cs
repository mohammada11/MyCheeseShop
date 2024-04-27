﻿namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];
        }

        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item == null)
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            else
                 item.Quantity += quantity;


            OnCartUpdated?.Invoke();
        }

        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }

        public int GetQuantity(Cheese cheese)
        {
            // return the quantity of the cheese in the cart
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
        }

        public void SetItems(IEnumerable<CartItem> items)
        {
            // set the items in the cart
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }
    }
}
