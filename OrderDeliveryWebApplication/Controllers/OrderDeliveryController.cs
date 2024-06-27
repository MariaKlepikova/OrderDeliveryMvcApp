using Microsoft.AspNetCore.Mvc;
using OrderDeliveryWebApplication.Domain.Models.Enums;
using OrderDeliveryWebApplication.Domain.Services;
using OrderDeliveryWebApplication.ViewModels.Mappers;
using OrderDeliveryWebApplication.ViewModels.Models.Requests;

namespace OrderDeliveryWebApplication.Controllers
{
    public class OrderDeliveryController : Controller
    {
        private readonly OrdersService _ordersService;
        
        public OrderDeliveryController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        
        // GET: OrderDelivery
        public async Task<IActionResult> Index()
        {
            var orders = await _ordersService.GetAllOrders();

            var responses = orders.Select(order => OrdersApiMapper.ToControllerResponse(order));
            
            return View(responses);
        }

        // GET: OrderDelivery/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _ordersService.GetOrderById(id);
            
            if (order == null)
            {
                return NotFound();
            }

            var response = OrdersApiMapper.ToControllerResponse(order);
            
            return View(response);
        }

        // GET: OrderDelivery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDelivery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderControllerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var order = OrdersApiMapper.ToDomain(request);
            
            var isSuccess = await _ordersService.CreateOrder(order);

            if (isSuccess is false)
            {
                return Problem();
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderDelivery/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _ordersService.GetOrderById(id);
            
            if (order == null)
            {
                return NotFound();
            }

            var response = OrdersApiMapper.ToUpdateRequestModel(order);
            
            return View(response);
        }

        // POST: OrderDelivery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateOrderControllerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var order = OrdersApiMapper.ToDomain(request, id);

            var result = await _ordersService.UpdateOrder(order);

            return result switch
            {
                UpdateOrderResult.NotFound => NotFound(),
                UpdateOrderResult.UnknownError => Problem(),
                _ => RedirectToAction(nameof(Index))
            };
        }

        // GET: OrderDelivery/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _ordersService.GetOrderById(id);
            
            if (order == null)
            {
                return NotFound();
            }

            var response = OrdersApiMapper.ToControllerResponse(order);

            return View(response);
        }

        // POST: OrderDelivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isSuccess = await _ordersService.DeleteOrder(id);
            
            if (isSuccess is false)
            {
                return Problem();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
