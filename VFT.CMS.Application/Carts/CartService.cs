using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Carts
{
    public class CartService
    {
        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";

        private readonly IHttpContextAccessor _context;

        private readonly HttpContext HttpContext;

        public CartService(IHttpContextAccessor context)
        {
            _context = context;
            HttpContext = context.HttpContext;
        }



        // Lấy cart từ Session (danh sách CartItem)
        public List<Cart> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<Cart>>(jsoncart);
            }
            return new List<Cart>();
        }

        // Xóa cart khỏi session
        public void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        public void SaveCartSession(List<Cart> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
    }
}
