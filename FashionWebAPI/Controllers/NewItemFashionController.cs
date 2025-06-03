using FashionWebAPI.Data;
using FashionWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewItemFashionController : ControllerBase
    {
        private readonly ApiContext _context;

        public NewItemFashionController(ApiContext context)
        {
            _context= context;
        }

        //Create-Edit
        [HttpPost]
        public JsonResult Create(NewFashionItems newFashionItems) { 
            if(newFashionItems.Id == 0)
            {
                _context.NewItem.Add(newFashionItems);
            }
            else
            {
                var FashionDB = _context.NewItem.Find(newFashionItems.Id);
                if (FashionDB == null) {
                    return new JsonResult(NotFound());
                }
                FashionDB = newFashionItems;
            }
                _context.SaveChanges();
                return new JsonResult(Ok(newFashionItems));
        
        }

        [HttpGet]
        public JsonResult Get(int id) {
            var result = _context.NewItem.Find(id);

            if (result == null) {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));

        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.NewItem.ToList();

            if (result == null || result.Count == 0)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));

        }

        [HttpDelete]
        public JsonResult Delete(int id) {
            var result = _context.NewItem.Find(id);
            if (result == null) {
                return new JsonResult(NotFound());
            }
            _context.NewItem.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        [HttpPost("Update")]

        public JsonResult Update(NewFashionItems newItem)
        {
            var result = _context.NewItem.Find(newItem.Id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            result.ItemName = newItem.ItemName;
            result.Description = newItem.Description;
            result.IsItemAvailable = newItem.IsItemAvailable;

            _context.SaveChanges();
            return new JsonResult(Ok(result));

        }
    }
}
