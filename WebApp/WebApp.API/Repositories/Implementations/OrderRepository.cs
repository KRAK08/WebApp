using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApp.API.Data;
using WebApp.API.Repositories.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Implementations
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(int userId, List<ProductOrder> details)
        {
            var data = new DataTable();
            data.Columns.Add("productid", typeof(int));
            data.Columns.Add("qty", typeof(int));
            data.Columns.Add("price", typeof(decimal));

            foreach (var item in details)
            {
                data.Rows.Add(item.ProductId, item.Qty, item.Price);
            }
            SqlParameter user = new SqlParameter("@userid", SqlDbType.Int);
            SqlParameter date = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter list = new SqlParameter("@lst", SqlDbType.Structured);
            user.Value = userId;
            date.Value = DateTime.Now;
            list.Value = data;
            list.TypeName = "dbo.productlist";

            await _dataContext.Database.ExecuteSqlInterpolatedAsync($"exec sp_registroVenta @lst={list},@userid={user},@date={date}");

            return true;
        }

        public override async Task<List<Order>> GetAllAsync()
        {
            return await _dataContext.Orders.Include(x => x.OrderDetails).ToListAsync();
        }

        public override async Task<Order> GetById(int id)
        {
            var data = await _dataContext.Orders
                                         .Include(x => x.OrderDetails)
                                         .FirstOrDefaultAsync(x => x.Id == id);
            return data!;
        }
    }
}