using Shop.Contexts;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Infrastructure
{
    public class CartManager
    {
        private ShopContext _db;
        private ISessionManager _session;
        public CartManager(ISessionManager session, ShopContext db)
        {
            _session = session;
            _db = db;
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (_session.Get<List<CartItem>>(SessionKey.CartSessionKey) == null) // check if someone is writed inside session if session is null then cart is empty
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = _session.Get<List<CartItem>>(SessionKey.CartSessionKey) as List<CartItem>;
            }
            
            return cart;
        }

        public void Add(int bookId)
        {
            var cart = GetCart();
            var item = cart.Find(i => i.Book.BookId == bookId);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                var BookToAdd = _db.Books
                    .Where(b => b.BookId == bookId)
                    .SingleOrDefault();

                if (BookToAdd != null)
                {
                    var newItem = new CartItem()
                    {
                        Book = BookToAdd,
                        Quantity = 1,
                        Value = BookToAdd.Price
                    };
                    cart.Add(newItem);
                }
            }

            _session.Set(SessionKey.CartSessionKey, cart); // adding to session
        }

        public int Remove(int bookId)
        {
            var cart = GetCart();
            var cartItem = cart.Find(i => i.Book.BookId == bookId);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }

            return 0;
        }

        public decimal GetCartValue()
        {
            var cart = GetCart();
            var cartValue = cart.Sum(x => (x.Quantity * x.Value));

            return cartValue;
        }

        public int GetQuantityOfCartItems()
        {
            var cart = GetCart();
            var quantity = cart.Sum(q => q.Quantity);

            return quantity;
        }

        public Order CreateOrder(Order order, string userId)
        {
            var cart = GetCart();

            order.DateAdded = DateTime.Now;
            order.UserID = userId;

            _db.Orders.Add(order);

            if (order.OrderItems == null)
                order.OrderItems = new List<OrderItem>();

            decimal cartValue = 0;
            foreach (var item in cart)
            {
                var orderItem = new OrderItem()
                {
                    BookID = item.Book.BookId,
                    Quantity = item.Quantity,
                    Value = item.Book.Price
                };

                cartValue += (item.Quantity * item.Book.Price);
                order.OrderItems.Add(orderItem);
            }

            order.OrderValue = cartValue;
            _db.SaveChanges();

            return order;
        }

        public void ClearCart() // delete session
        {
            _session.Set<List<CartItem>>(SessionKey.CartSessionKey, null); // clear cart
        }
    }
}

