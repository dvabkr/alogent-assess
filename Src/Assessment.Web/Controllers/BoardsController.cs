using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assessment.Web.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Web.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : Controller
    {
        public IBoardRepository boards;

        public BoardsController(IBoardRepository boards)
        {
            this.boards = boards;
        }

        [HttpGet]
        public IEnumerable<Board> GetAll()
        {
            return boards.GetAll();
        }

        [HttpGet("{id}")]
        public Board Find(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Board ID must be greater than zero.");

            return boards.Find(id);
        }

        [HttpGet]
        public List<Board> Get()
        {
            using (BPDbContext db = new
               BPDbContext())
            {
                return db.Boards.ToList();
            }
        }

        [HttpGet("{id}")]
        public Board Get(int id)
        {
            using (BPDbContext db = new
               BPDbContext())
            {
                return db.Boards.Find(id);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Board obj)
        {
            using (BPDbContext db = new BPDbContext())
            {
                db.Boards.Add(obj);
                db.SaveChanges();
                return new ObjectResult("Board added successfully!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (BPDbContext db = new BPDbContext())
            {

                db.Boards.Remove(db.Boards.Find(id));
                db.SaveChanges();
                return new ObjectResult("Board deleted successfully!");
            }
        }

    }
}
