using Bll.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {   
        private readonly ITrip tripBll;
        private readonly ITripType tripTypeBll;
        private readonly IOrderTicket orderTicketBll;

        public TripController(ITrip trip, ITripType tripType, IOrderTicket orderTicket)
        {
            this.tripBll = trip;
            this.tripTypeBll = tripType;
            this.orderTicketBll = orderTicket;
        }
        
        [HttpGet]
        [Route("AllTrips")]
        public async Task<List<Dto.Classes.Trip>> GetTripsAsync()
        {
            return await tripBll.GetAllAsync();
        }
        [HttpGet]
        [Route("TripsType")]
        public async Task<List<Dto.Classes.TripType>> GetTripsTypeAsync()
        {
            return await tripTypeBll.GetAllAsync();
        }
        [HttpGet]
        [Route("TripById")]
        public async Task<Dto.Classes.Trip> GetTripById(int id)
        {
            return await tripBll.GetByIdAsync(id);
        }

        [HttpPut]
        [Route("InviteToTripById")]
        public async Task<List<Dto.Classes.OrderTicket>> GetInviteToTripById(Dto.Classes.Trip trip)
        {
            return await tripBll.getInvitesToTripAsync(trip);
        }

        [HttpGet]
        [Route("Orders")]
        public async Task<List<Dto.Classes.OrderTicket>> GetOrders()
        {
            return await orderTicketBll.GetAllAsync();
        }

        [HttpPost]
        [Route("trip")]
        public async Task<int> addTrip(Dto.Classes.Trip trip)
        {

            return await tripBll.AddAsync(trip);
        }

        [HttpPut]
        [Route("trip")]
        public async Task<bool> updateTrip(Dto.Classes.Trip trip)
        {
            return await tripBll.UpdateAsync(trip); 
        }
        [HttpPost]
        [Route("orderTrip")]
        public async Task<int> addInviteToTrip(Dto.Classes.OrderTicket order)
        {
            return await orderTicketBll.AddOrderAsync(order);
        }
        [HttpDelete]
        [Route("order/{id}")]
        public async Task<bool> deleteOrder(int id)
        {
            return await orderTicketBll.DeleteAsync(id);
        }

    }
}