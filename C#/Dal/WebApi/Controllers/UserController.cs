using Bll.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUser userBll;
        private readonly ITrip tripBll;
        private readonly ITripType tripTypeBll;
        private readonly IOrderTicket orderTicketBll;

        public UserController(IUser user, ITrip trip, ITripType tripType, IOrderTicket orderTicket)
        {
            this.userBll = user;
            this.tripBll = trip;
            this.tripTypeBll = tripType;
            this.orderTicketBll = orderTicket;
        }

        [HttpGet]
        [Route("AllUsers")]
        public async Task<List<Dto.Classes.User>> GetUsersAsync()
        {
            return await userBll.GetAllAsync();
        }

        [HttpGet]
        [Route("User/{mail}/{password}")]
        public async Task<Dto.Classes.User> GetUserByMailAndPassword(string mail, string password)
        {
            return await userBll.GetByMailAndPasswordAsync(mail,password);
        }

        [HttpGet]
        [Route("GetAllTripsToUser/{id}")]
        public async Task<List<Dto.Classes.Trip>> GetAllTripsToUser(int id)
        {
            return await userBll.GetAllTripsToUserAsync(id);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<int> AddUser(Dto.Classes.User user)
        {
            return await userBll.AddAsync(user);
        }
        [HttpDelete]
        [Route("User/{id}")]
        public async Task<bool> deleteUser(int id)
        {
            return await userBll.DeleteAsync(id);
        }
        [HttpPatch]
        [Route("updateUser")]
        public async Task<bool> updateUser(Dto.Classes.User user)
        {
            return await userBll.UpdateAsync(user);
        }
    }
}
