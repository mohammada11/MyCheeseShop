namespace MyCheeseShop.Model
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
            // Returns the quantity of the cheese in the cart
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
        }
        public int Count()
        {
           
            return _items.Count;
        }

        public decimal Total()
        {
            // Returns the total price of the item in the cart 
            return _items.Sum(item => item.Cheese.Price * item.Quantity);
        }

        public void SetItems(IEnumerable<CartItem> items)
        {
            // Set the items in the cart
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }

        public void RemoveItem(Cheese cheese)
        {
            // Removes the selected item completely from the cart
            var item = _items.RemoveAll(item => item.Cheese.Id ==  cheese.Id);
            OnCartUpdated?.Invoke();

        }

        public void RemoveItem(Cheese cheese, int quantity)
        {
            // Decreases the quantity in the cart by 1 
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if(item is not null)
            {
                item.Quantity = quantity;
                if(item.Quantity <= 0)
                _items.Remove(item);
            }
            OnCartUpdated?.Invoke();

        }

        public void Clear()
        { 
           _items.Clear(); 
           OnCartUpdated?.Invoke();
        }
    }
}
