using Domain.DTOs;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service;
using Infrastructure.Service.IOrderService;
using Infrastructure.Service.IOrderService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet("GetAllOrders")]
    public async Task<Response<List<Order>>> GetAll()
    {
        var response = await orderService.GetAll();
        return response;
    }
    [HttpGet("GetOrderByPhone")]
    public async Task<Response<Order>> GetOrderById(int id)
    {
        return orderService.GetById(id).Result;
    }

    [HttpPost("AddOrder")]
    public async Task<Response<bool>> Create(Order product)
    {
        var response = await orderService.Create(product);
        return response;
    }

    [HttpPut("UpdateOrder")]
    public async Task<Response<bool>> UpdateOrder(Order product)=> await orderService.Update(product);

    [HttpDelete("DeleteOrder")]
    public async Task<Response<bool>> Delete(int id)
    {
        var response = await orderService.Delete(id);
        return response;
    }

    [HttpGet("GetOrdersByDate")]
    public async Task<Response<List<ByDateDTO>>> GetOrdersByPeriod(DateTime startDate, DateTime endDate)=> await orderService.GetByDate(startDate, endDate);

    
}